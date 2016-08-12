using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    public class DrawManager
    {
        public Bitmap Bitmap { get; set; }
        private Graphics canvas;
        private Graphics screen;
        
        public DrawManager(Graphics screen, int gridWidth, int cellWidth)
        {
            Bitmap = new Bitmap(gridWidth * cellWidth, gridWidth * cellWidth);
            canvas = Graphics.FromImage(Bitmap);
            this.screen = screen;
            
        }

        public void DrawToScreen()
        {
            screen.DrawImage(Bitmap, new Point(0, 0));
        }

        public void DrawCellToCanvas(Brush brush, int x, int y, int cellWidth)
        {
            canvas.FillRectangle(brush, x * cellWidth, y * cellWidth, cellWidth, cellWidth);
        }

    }
}
