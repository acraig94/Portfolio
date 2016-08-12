using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    // Enum for neighbours positions relative to cell. eg. NW == NORTH WEST , SE == SOUTH EAST
    enum Neighbour {NW = 0, N = 1, NE = 2, W = 3, E = 4, SW = 5, S = 6, SE = 7};
    //public delegate double ConcentrationDelegate(double concentration);
    public interface ILaplacianFactory
    {
        double ComputeA(double a, Cell[] n);
        double ComputeB(double b, Cell[] n);
    }


}
