using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    public class AutomaticSimulation
    {
        // Number of laplacian functions
        private const int NLAPLACIAN = 3;
        // Laplacian function used
        private ILaplacianFactory algorithm;
        // Brush factory used - by default its set as short long.
        private IBrushFactory brush;
        // Graphics variable
        private Graphics screen;
        // Variables used for the feed & kill rates range
        private double fMin;
        private double fMax;
        private double kMin;
        private double kMax;
        // simulation instance
        private Simulation sim;

        public AutomaticSimulation(Graphics screen)
        {
            // Ideal ranges for finding patterns
            fMin = 0.01;
            fMax = 0.1;
            kMin = 0.045;
            kMax = 0.07;
            //
            this.screen = screen;
            // Set default brush - has no affect on pattern apart from colour 
            brush = new ShortRainbowFactory();
        }
        // Runs through each feed & kill rate with each Laplacian function and saves a copy of the image
        public void Run()
        {
            for (double i = fMin; i < fMax; i+= 0.01)
            {
                for (double j = kMin; j < kMax; j+= 0.01)
                {
                    for (int l = 0; l < NLAPLACIAN; l++)
                    {                        
                        algorithm = ChangeLapFunc(l);
                        sim = new Simulation(screen, algorithm, brush, i, j);
                        sim.QuickCycle();
                        sim.SaveImage();
                    }
                }
            }
        }
        // used to switch the laplacian function
        public ILaplacianFactory ChangeLapFunc(int i)
        {
            ILaplacianFactory algorithm;
            switch (i)
            {
                case 0:
                    algorithm = new PerpendicularFunction();
                    break;
                case 1:
                    algorithm = new ConvolutionFunction();
                    break;
                case 2:
                    algorithm = new DeltaFunction();
                    break;
                default:
                    algorithm = null;
                    break;
            }
            return algorithm;
        }


    }
}
