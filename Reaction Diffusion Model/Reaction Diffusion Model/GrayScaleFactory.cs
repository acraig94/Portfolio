using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    public class GrayScaleFactory : IBrushFactory
    {
        public Brush CreateNewBrush(double b)
        {
            double x = b * 255;
            double y = Math.Floor(x);
            int c = Convert.ToInt32(y);
            Color colour = Color.FromArgb(c, c, c);
            return new SolidBrush(colour);
        }
    }
}
