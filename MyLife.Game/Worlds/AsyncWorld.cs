using MyLife.Game.Interfaces;
using MyLife.Game.Worlds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyLife.Game.Worlds
{
    /// <summary>
    /// This is a dumb implementation of sync version. Actually we need to redesign the model implementation too. 
    /// At least it should lock all methods execution. 
    /// </summary>
    public class AsyncWorld : BasicWorld, IGameAsync
    {
        //TODO: Very, very poor implementation. It's not thread-safe but working.
        //TODO: Draft implementation! 
        public class AdaptedToSyncModel : HashModel
        {
            class AdaptedGeneration : Generation
            {
                public AdaptedGeneration(HashModel model):base(model)
                {

                }
                
                // Sets async mode off
                public override void Dispose()
                {
                    base.Dispose();
                    (owner as AdaptedToSyncModel).InAsync = false;
                }
            }

            public AdaptedToSyncModel()
            {
                generation = new AdaptedGeneration(this);
            }

            protected bool InAsync { get; set; }

            // Just skip all notifications in the async mode
            protected override void OnChanged(EventArgs e)
            {
                if (InAsync)
                    return;

                base.OnChanged(e);
            }

            // Sets async mode on
            public override IGeneration StartGeneration()
            {
                InAsync = true;
                return base.StartGeneration();
            }
        }

        /// <summary>
        /// Asynchronous implementation
        /// </summary>
        /// <param name="model">Model instance</param>
        /// <param name="complete">The complete action routine that is executed in the synchronization context of caller</param>
        public void EvolveAsync(IModel model, Action complete)
        {
            SynchronizationContext ctx = new SynchronizationContext();
            
            ThreadPool.QueueUserWorkItem(new WaitCallback( (obj) => {
                
                base.Evolve(model);
                
                ctx.Post(new SendOrPostCallback((o) => {
                    complete();
                }), null);
            }));
        }
    }
}
