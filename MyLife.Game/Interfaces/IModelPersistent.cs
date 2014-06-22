using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyLife.Game.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public class CellArea
    {
        public long OffsetX { get; set; }
        public long OffsetY { get; set; }
        public long Width { get; set; }
        public long Height { get; set; }
    }

    /// <summary>
    /// Represents an interface for model persistence
    /// </summary>
    public interface IModelPersistent
    {
        /// <summary>
        /// Initializes model from bag
        /// </summary>
        /// <param name="map"></param>
        void Initialize(ICellBag bag);

        /// <summary>
        /// Flush model to bag and use criteria for conditions
        /// </summary>
        /// <param name="bag">The bag storage</param>
        /// <param name="criteria">The criteria. Use null value for all cells</param>
        void Flush(ICellBag bag, CellArea criteria);
    }
}
