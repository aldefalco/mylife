using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLife.Game.Worlds;
using MyLife.Game;

namespace MyLife.WindowsFormsApp
{
    /// <summary>
    /// The Conway's life game board
    /// </summary>
    public partial class GameBoardControl : UserControl
    {
        private IWorld world;
        //private bool dirty;
        //private BufferedGraphicsContext bufferContext;
        //private BufferedGraphics buffer;
        private Pen cellPen = new Pen(Brushes.Green);
        private HashSet<Cell> init = new HashSet<Cell>();

        public GameBoardControl()
        {
            world = new SimpleWorld();
            //bufferContext = new BufferedGraphicsContext();
            //SizeGraphicsBuffer();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        /*
        private void SizeGraphicsBuffer()
        {
            
            if (buffer != null)
            {
                buffer.Dispose();
                buffer = null;
            }

            if (bufferContext == null)
                return;

            if (DisplayRectangle.Width <= 0)
                return;

            if (DisplayRectangle.Height <= 0)
                return;

            using (Graphics graphics = CreateGraphics())
                buffer = bufferContext.Allocate(graphics, DisplayRectangle);

            InvalidateBuffer();
        }
         * */

        protected override void OnPaintBackground(PaintEventArgs pevent)
        { 
        }

        /*
        protected override void OnSizeChanged(EventArgs e)
        {
            SizeGraphicsBuffer();
            base.OnSizeChanged(e);
        }
         * */

        /*
        private void InvalidateBuffer()
        {
            dirty = true;
            Invalidate();
        }
         * */

        protected override void OnPaint(PaintEventArgs e)
        {
            Draw(e.Graphics);
            /*
            if (buffer == null)
            {
                Draw(e.Graphics);
                return;
            }

            if (dirty)
            {
                dirty = false;
                buffer.cl
                Draw(buffer.Graphics);
            }

            buffer.Render(e.Graphics);
             * */
        }

        public virtual void Draw(Graphics graphics)
        {
            foreach (var cell in world.Cells)
            {
                graphics.DrawRectangle(cellPen, cell.X * 5, cell.Y * 5, 5, 5);
            }

            //graphics.DrawRectangle(cellPen, 10, 10, 500, 500);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (disposing)
            {
                /*
                if (buffer != null)
                {
                    buffer.Dispose();
                    buffer = null;
                }

                if (bufferContext != null)
                {
                    bufferContext.Dispose();
                    bufferContext = null;
                }
                 * */

                if (cellPen != null)
                {
                    cellPen.Dispose();
                    cellPen = null;
                }
            }

            base.Dispose(disposing);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            world.Invert(new Cell(e.X/5, e.Y/5));
            Invalidate();
        }

        public void Turn()
        {
            world.NextGeneration();
            Invalidate();
        }

    }
}
