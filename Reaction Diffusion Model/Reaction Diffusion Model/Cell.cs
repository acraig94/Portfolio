using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reaction_Diffusion_Model
{
    public class Cell
    {
        public enum Concentration { ConcentrationA, ConcentrationB };
        // Position of cell in grid
        public Point Position { get; set; }
        // Concentrations
        public double ConA;
        public double ConB;
        private double nextA;
        private double nextB;
        // Params
        private double diffA;
        private double diffB;
        private double feedA;
        private double killB;
        // Neighbours array
        public Cell[] NeighbourCells { get; set; }
        // Sizes - width of cell - passed in from grid
        private int cellWidth;
        // Laplacian Function
        private ILaplacianFactory lapFunc;
        // Brush Factory 
        private IBrushFactory brushFactory;

        private DrawManager dm;

        public Cell(DrawManager dm, IBrushFactory brushFactory, Point Position, int cellWidth, ILaplacianFactory lapFunc, double diffA, double diffB, double feedA, double killB)
        {
            // Canvas
            this.dm = dm;
            // Position X & Y
            this.Position = Position;
            // Width & height of cell
            this.cellWidth = cellWidth;
            // Params
            this.diffA = diffA;
            this.diffB = diffB;
            this.feedA = feedA;
            this.killB = killB;
            // Init concentration
            ConA = 1.0;
            ConB = 0.0;
            // Laplacian Function
            this.lapFunc = lapFunc;
            // Brush Factory
            this.brushFactory = brushFactory;
        }
        // Draws cell to canvas
        public void Draw()  
        {
            //Console.WriteLine(Position.X+", "+Position.Y+"\t :: ConA = "+ ConA + "\t :: ConB = " + ConB);
            Brush brush = brushFactory.CreateNewBrush(ConB);
            dm.DrawCellToCanvas(brush, Position.X, Position.Y, cellWidth);
        }
        // Computes the new values of both concentrations
        public void ComputeNewConcentrations()
        {
            double updateA = ConA + (diffA * lapFunc.ComputeA(ConA, NeighbourCells)) - (ConA * ConB * ConB) + (feedA * (1 - ConA));
            double updateB = ConB + (diffB * lapFunc.ComputeB(ConB, NeighbourCells)) + (ConA * ConB * ConB) - ((killB + feedA) * ConB);
            nextA = CheckConcentrationBoundries(updateA);
            nextB = CheckConcentrationBoundries(updateB);
        }
        // Updates concentrations with the new values
        public void UpdateCell()
        {
            ConA = nextA;
            ConB = nextB;
        }
        // Changes concentration values to make cell a seed
        public void MakeSeed()
        {
            ConA = 0.1;
            ConB = 1.0;
        }
        // Ensures that concentration value is between 0 & 1
        public double CheckConcentrationBoundries(double x)
        {
            double result = x;
            if (result > 1.0)
            {
                result = 1.0;
            }
            if (result < 0.0)
            {
                result = 0.0;
            }
            return result;
        }

        



    }
}
