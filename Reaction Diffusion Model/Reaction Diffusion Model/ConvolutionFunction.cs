using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    public class ConvolutionFunction : ILaplacianFactory
    {
        private double NW;
        private double N;
        private double NE;
        private double W;
        private double C;
        private double E;
        private double SW;
        private double S;
        private double SE;

        public double ComputeA(double x, Cell[] n)
        {
            NW = n[(int)Neighbour.NW].ConA * 0.05;
            N = n[(int)Neighbour.N].ConA * 0.2;
            NE = n[(int)Neighbour.NE].ConA * 0.05;
            W = n[(int)Neighbour.W].ConA * 0.2;
            C = x * -1;
            E = n[(int)Neighbour.E].ConA * 0.2;
            SW = n[(int)Neighbour.SW].ConA * 0.05;
            S = n[(int)Neighbour.S].ConA * 0.2;
            SE = n[(int)Neighbour.SE].ConA * 0.05;
            return NW + N + NE + W + C + E + SW + S + SE;
        }

        public double ComputeB(double x, Cell[] n)
        {
            NW = n[(int)Neighbour.NW].ConB * 0.05;
            N = n[(int)Neighbour.N].ConB * 0.2;
            NE = n[(int)Neighbour.NE].ConB * 0.05;
            W = n[(int)Neighbour.W].ConB * 0.2;
            C = x * -1;
            E = n[(int)Neighbour.E].ConB * 0.2;
            SW = n[(int)Neighbour.SW].ConB * 0.05;
            S = n[(int)Neighbour.S].ConB * 0.2;
            SE = n[(int)Neighbour.SE].ConB * 0.05;
            return NW + N + NE + W + C + E + SW + S + SE;
        }

    }
}
