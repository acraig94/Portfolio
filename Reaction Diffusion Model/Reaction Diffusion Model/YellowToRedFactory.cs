using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    public class YellowToRedFactory : IBrushFactory
    {
        public Brush CreateNewBrush(double b)
        {
            double x = (1 - b);
            int y = Convert.ToInt32(Math.Floor(255*x));
            Color colour = Color.FromArgb(255, y, 0);
            return new SolidBrush(colour);
        }
    }
}
