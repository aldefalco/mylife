using MyLife.Game.Data;
using MyLife.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Worlds
{
    /// <summary>
    /// This is a data model implementation for life game based on HashSets. It's not thread-safe
    /// </summary>
    public class HashModel : IModel, IModelPersistent
    {
        private HashSet<Cell> liveSet = new HashSet<Cell>();
        
        protected Generation generation;
        protected Editor editor;

        /// <summary>
        /// Nested helper class for IGeneration implementation
        /// </summary>
        protected class Generation : IGeneration
        {
            protected HashModel owner;
            private HashSet<Cell> generationSet = new HashSet<Cell>();
            private HashSet<Cell> deadSet = new HashSet<Cell>();
            private bool commited = false;

            public Generation(HashModel owner)
            {
                this.owner = owner;
            }

            public virtual void CollectAlive(Cell cell)
            {
                generationSet.Add(cell);
                commited = false;
            }

            public virtual void Dispose()
            {
                if (commited)
                {
                    var swap = owner.liveSet;
                    owner.liveSet = generationSet;
                    generationSet = swap;
                    generationSet.Clear();
                    deadSet.Clear();
                    owner.OnChanged(EventArgs.Empty);
                }
            }

            public virtual int CollectDead(IEnumerable<Cell> cells)
            {
                int count = 0;
                foreach(Cell cell in cells){
                    deadSet.Add(cell);
                    count++;
                }
                commited = false;
                return count;
            }

            public virtual IEnumerable<Cell> Dead { get { return deadSet; } }

            public virtual void Commit()
            {
                commited = true;
            }
        }

        protected class Editor : IModelEditor
        {
            private HashModel owner;
            private bool commited = false;

            public Editor(HashModel owner)
            {
                this.owner = owner;
            }

            public virtual void Set(Cell cell)
            {
                this.owner.liveSet.Add(cell);
                commited = false;
            }

            public virtual void Invert(Cell cell)
            {
                commited = false;
                if (this.owner.liveSet.Contains(cell))
                    this.owner.liveSet.Remove(cell);
                else
                    this.owner.liveSet.Add(cell);
            }

            public virtual void Reset(Cell cell)
            {
                commited = false;
                if (this.owner.liveSet.Contains(cell))
                    this.owner.liveSet.Remove(cell);
            }

            public virtual void Commit()
            {
                commited = true;
                this.owner.OnChanged(EventArgs.Empty);
            }

            //TODO: implement commit paterns
            public virtual void Dispose()
            {
                
            }
        }

        public HashModel()
        {
            generation = new Generation(this);
            editor = new Editor(this);
        }

        public virtual void Initialize(ICellBag map)
        {
            liveSet = new HashSet<Cell>(map.Iterator);
            OnChanged(EventArgs.Empty);
        }

        public virtual void Flush(ICellBag map, CellArea criteria)
        {
            IEnumerable<Cell> result = liveSet;
            if (criteria != null)
            {
                result = liveSet.Where(cell =>
                    cell.X > criteria.OffsetX && cell.X < criteria.OffsetX + criteria.Width &&
                    cell.Y > criteria.OffsetY && cell.Y < criteria.OffsetY + criteria.Width);
            }
            map.Fill(result);
        }

        public virtual bool IsCellAlive(Cell cell)
        {
            return liveSet.Contains(cell);
        }

        public virtual IEnumerable<Cell> Alive { get { return liveSet; } }

        public virtual IGeneration StartGeneration()
        {
            return generation;
        }

        public virtual IModelPersistent ModelPersistent
        {
            get { return this; }
        }

        public virtual IModelEditor ModelEditor
        {
            get { return editor; }
        }

        public virtual void Clear()
        {
            liveSet.Clear();
            OnChanged(EventArgs.Empty);
        }

        public event EventHandler Changed;

        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
                Changed(this, e);
        }
    }
}
