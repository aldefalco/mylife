using MyLife.Game.Data;
using MyLife.Game.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLife.WindowsFormsApp
{
    /// <summary>
    /// Class for binary serialization of life cells
    /// </summary>
    class GameFileStorage : ICellBag
    {
        private string fileName;

        /// <summary>
        /// Implements a stream iterator
        /// </summary>
        class Reader : IEnumerable<Game.Data.Cell>
        {
            private GameFileStorage owner;

            public Reader(GameFileStorage owner)
            {
                this.owner = owner;
            }

            public IEnumerator<Game.Data.Cell> GetEnumerator()
            {
                using (var fs = new FileStream(owner.fileName, FileMode.Open, FileAccess.Read))
                {
                    using(var reader = new BinaryReader(fs))
                    {
                            while (true)
                            {
                                Cell cell;
                                try
                                {
                                    cell = new Cell(reader.ReadInt64(), reader.ReadInt64());
                                }
                                catch (EndOfStreamException) { yield break; }
                                yield return cell;
                            }
                    }
                }
            }

            //TODO: Fix it
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public GameFileStorage(string fileName)
        {
            this.fileName = fileName;
        }

        public IEnumerable<Game.Data.Cell> Iterator
        {
            get 
            {
                return new Reader(this);
            }
        }

        public void Fill(IEnumerable<Game.Data.Cell> cells)
        {
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var writer = new BinaryWriter(fs))
                {
                    foreach(var cell in cells)
                    {
                        writer.Write(cell.X);
                        writer.Write(cell.Y);
                    }
                }
            }
        }
    }
}
