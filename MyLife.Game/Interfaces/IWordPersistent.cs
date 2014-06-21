using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Interfaces
{
    public class FlushCriteria
    {
        public long OffsetX { get; set; }
        public long OffsetY { get; set; }
        public long Width { get; set; }
        public long Height { get; set; }
    }
    public interface IWorldPersistent
    {
        void Initialize(IMap map);
        void Flush(IMap map, FlushCriteria criteria);
    }
}
