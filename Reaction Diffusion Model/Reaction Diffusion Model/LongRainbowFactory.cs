using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    public class LongRainbowFactory : IBrushFactory
    {
        public Brush CreateNewBrush(double b)
        {
            double z = (1 - b) / 0.2;
            int x = Convert.ToInt32(Math.Floor(z));
            int y = Convert.ToInt32(Math.Floor(255 * (z - x)));
            Color colour;
            int red = 0, green = 0, blue = 0;
            switch (x)
            {
                case 0: red = 255; green = y; blue = 0; break;
                case 1: red = 255 - y; green = 255; blue = 0; break;
                case 2: red = 0; green = 255; blue = y; break;
                case 3: red = 0; green = 255 - y; blue = 255; break;
                case 4: red = y; green = 0; blue = 255; break;
                case 5: red = 255; green = 0; blue = 255; break;
            }
            colour = Color.FromArgb(red, green, blue);
            return new SolidBrush(colour);
        }
    }
}
