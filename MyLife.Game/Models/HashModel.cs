using MyLife.Game.Data;
using MyLife.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Models
{
    /// <summary>
    /// This is a game data model implementation based on HashSets
    /// </summary>
    public class HashModel : IModel, IModelPersistent
    {
        //private HashSet<Cell> deadSet = new HashSet<Cell>();
        private HashSet<Cell> liveSet = new HashSet<Cell>();
        
        private Generation generation;
        private Editor editor;

        /// <summary>
        /// Nested helper class for IGeneration implementation
        /// </summary>
        class Generation : IGeneration
        {
            private HashModel owner;
            private HashSet<Cell> generationSet = new HashSet<Cell>();
            private HashSet<Cell> deadSet = new HashSet<Cell>();
            private bool commited = false;

            public Generation(HashModel owner)
            {
                this.owner = owner;
            }

            public void CollectAlive(Cell cell)
            {
                generationSet.Add(cell);
                commited = false;
            }

            public void Dispose()
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

            public int CollectDead(IEnumerable<Cell> cells)
            {
                int count = 0;
                foreach(Cell cell in cells){
                    deadSet.Add(cell);
                    count++;
                }
                commited = false;
                return count;
            }

            public IEnumerable<Cell> Dead { get { return deadSet; } }

            public void Commit()
            {
                commited = true;
            }
        }

        class Editor : IModelEditor
        {
            private HashModel owner;
            private bool commited = false;

            public Editor(HashModel owner)
            {
                this.owner = owner;
            }

            public void Set(Cell cell)
            {
                this.owner.liveSet.Add(cell);
                commited = false;
            }

            public void Invert(Cell cell)
            {
                commited = false;
                if (this.owner.liveSet.Contains(cell))
                    this.owner.liveSet.Remove(cell);
                else
                    this.owner.liveSet.Add(cell);
            }

            public void Reset(Cell cell)
            {
                commited = false;
                if (this.owner.liveSet.Contains(cell))
                    this.owner.liveSet.Remove(cell);
            }

            public void Commit()
            {
                commited = true;
                this.owner.OnChanged(EventArgs.Empty);
            }

            //TODO: implement commit paterns
            public void Dispose()
            {
                
            }
        }

        public HashModel()
        {
            generation = new Generation(this);
            editor = new Editor(this);
        }

        public void Initialize(ICellBag map)
        {
            liveSet = new HashSet<Cell>(map.Iterator);
            OnChanged(EventArgs.Empty);
        }

        public void Flush(ICellBag map, CellArea criteria)
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

        public bool IsCellAlive(Cell cell)
        {
            return liveSet.Contains(cell);
        }
        
        public IEnumerable<Cell> Alive { get { return liveSet; } }

        public IGeneration StartGeneration()
        {
            return generation;
        }

        public IModelPersistent ModelPersistent
        {
            get { return this; }
        }

        public IModelEditor ModelEditor
        {
            get { return editor; }
        }

        public void Clear()
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
