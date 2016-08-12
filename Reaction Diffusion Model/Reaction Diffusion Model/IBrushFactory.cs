using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    public interface IBrushFactory
    {
        Brush CreateNewBrush(double b);
    }
}
