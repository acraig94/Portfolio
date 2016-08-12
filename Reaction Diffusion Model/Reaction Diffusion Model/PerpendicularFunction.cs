using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    public class PerpendicularFunction : ILaplacianFactory
    {

        public double ComputeA(double x, Cell[] n)
        {
            double h = 2.5 / 127.0;
            double rh = 1.0 / h / h;
            
            // y = sum of the concentration of X for the four perpendicular neighbours
            double y = n[(int)Neighbour.N].ConA + n[(int)Neighbour.W].ConA + n[(int)Neighbour.E].ConA + n[(int)Neighbour.S].ConA;
            
            return rh * (y - (4 * x));
        }
        public double ComputeB(double x, Cell[] n)
        {
            double h = 2.5 / 127.0;
            double rh = 1.0 / h / h;

            // y = sum of the concentration of X for the four perpendicular neighbours
            double y = n[(int)Neighbour.N].ConB + n[(int)Neighbour.W].ConB + n[(int)Neighbour.E].ConB + n[(int)Neighbour.S].ConB;
            
            return rh * (y - (4 * x));
        }

    }
}
