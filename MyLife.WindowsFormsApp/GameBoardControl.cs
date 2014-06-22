using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLife.Game.Interfaces;
using MyLife.Game.Data;
using MyLife.Game.Models;
using MyLife.Game.Common;

namespace MyLife.WindowsFormsApp
{
    /// <summary>
    /// The Conway's life game board
    /// </summary>
    public partial class GameBoardControl : UserControl
    {
        /// <summary>
        /// Size cell in pixels
        /// </summary>
        const int CELL_SIZE = 5;

        /// <summary>
        /// Life game word instance
        /// </summary>
        private IWorld world;

        /// <summary>
        /// This is a buffer for drawing purposes
        /// </summary>
        private HashBuffer buffer = new HashBuffer();

        /// <summary>
        /// Area that is visible on screen
        /// </summary>
        private CellArea visibleArea = null;

        private Pen cellPen = new Pen(Brushes.Green);
        private Font font = new Font(FontFamily.GenericMonospace, 16f);


        public GameBoardControl()
        {
            world = new BasicWorld(new HashModel());
            world.Model.Changed += (sender, args) =>
            {
                var model = sender as IModel;
                model.ModelPersistent.Flush(buffer, visibleArea);
                Invalidate();
            };

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        public void Turn()
        {
            world.Evolve();
        }

        public void SaveToFile(string fileName)
        {
            var storage = new GameFileStorage(fileName);
            world.Model.ModelPersistent.Flush(storage, null);
        }

        public void LoadFromFile(string fileName)
        {
            var storage = new GameFileStorage(fileName);
            world.Model.ModelPersistent.Initialize(storage);
        }

        public void Clear()
        {
            world.Model.Clear();
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        { 
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            visibleArea = new CellArea { OffsetX=0, OffsetY=0,
                                                Width = DisplayRectangle.Width / CELL_SIZE,
                                                Height = DisplayRectangle.Height / CELL_SIZE
            }; 
            base.OnSizeChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            world.Model.ModelEditor.Invert(new Cell(e.X / CELL_SIZE, e.Y / CELL_SIZE));
            world.Model.ModelEditor.Commit();
        }

        public virtual void Draw(Graphics graphics)
        {
            foreach (var cell in buffer.cells)
            {
                graphics.DrawRectangle(cellPen, cell.X * CELL_SIZE, cell.Y * CELL_SIZE, 
                    CELL_SIZE, CELL_SIZE);
            }

            graphics.DrawString(string.Format("Generation:{0}", world.Generation), font, 
                Brushes.Gold, 10, 10);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (disposing)
            {
                if (cellPen != null)
                {
                    cellPen.Dispose();
                    cellPen = null;
                }

                if (font != null)
                {
                    font.Dispose();
                    font = null;
                }
            }

            base.Dispose(disposing);
        }

    }
}
