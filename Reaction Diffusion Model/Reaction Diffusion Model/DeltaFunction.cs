using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    public class DeltaFunction : ILaplacianFactory
    {
        public double ComputeA(double x, Cell[] n)
        {
            double nAverage;
            double sum = 0;
            foreach (Cell c in n)
            {
                sum += c.ConA;
            }
            nAverage = sum / 8;
            return nAverage - x;
        }

        public double ComputeB(double x, Cell[] n)
        {
            double nAverage;
            double sum = 0;
            foreach (Cell c in n)
            {
                sum += c.ConB;
            }
            nAverage = sum / 8;
            return nAverage - x;
        }
    }
}
