using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing.Imaging;
using Microsoft.Win32;
using System.Drawing.Drawing2D;

namespace Reaction_Diffusion_Model
{
    public class Simulation
    {
        private const int GRID_WIDTH = 128; // number of cells wide
        private const int CELL_WIDTH = 3; // width of cells
        private const int SIMULATION_LENGTH = 5000; // number of timer ticks for the simulation
        
        // Graphics used to draw bitmap to screen
        Graphics canvas;
        // Grid Instance
        Grid grid;
        // Number of timer ticks
        int simCount;

        SaveBitmap sm;
        // Instance of DrawManager
        DrawManager dm;

        public Simulation(Graphics canvas, ILaplacianFactory algorithm, IBrushFactory brush, double feedRate, double killRate)
        {
            this.canvas = canvas;
            dm = new DrawManager(canvas, GRID_WIDTH, CELL_WIDTH);
            sm = new SaveBitmap(feedRate, killRate, algorithm);
            // Creates Grid instance
            grid = new Grid(dm, algorithm, brush, feedRate, killRate, GetDiffA(algorithm), GetDiffB(algorithm), GRID_WIDTH, CELL_WIDTH);
            // count for simulation
            simCount = 0;

            
        }
        // Runs the entire simulation without draw at each timer tick speeding the process up
        public void QuickCycle()
        {
            for (int i = 0; i < SIMULATION_LENGTH; i++)
            {
                grid.ComputeConcentrations();
                grid.UpdateCells();
                simCount++;
            }
            grid.DrawCells(); // draws cells to bitmap
            //dm.DrawToScreen(); // draws bitmap to screen
            Console.WriteLine("Finished simulation");
        }
        // Runs the entire simulation
        public void Cycle()
        {
            if (simCount < SIMULATION_LENGTH)
            {
                grid.ComputeConcentrations();
                grid.UpdateCells();
                grid.DrawCells();
                simCount++;
            }
            else
            {
                Console.WriteLine("Finished simulation");
            }
                     
        }
        // Used to save the bitmap
        public void SaveImage()
        {
            sm.SaveCanvas(dm.Bitmap);
        }
        // Get the Diff A value based on the Laplacian Factory chosen
        private double GetDiffA(ILaplacianFactory a)
        {
            if (a is PerpendicularFunction)
            {
                return 0.00002;
            }
            else
            {
                return 1.0;
            }
        }
        // Get the Diff B value based on the Laplacian Factory chosen
        private double GetDiffB(ILaplacianFactory a)
        {
            if (a is PerpendicularFunction)
            {
                return 0.00001;
            }
            else
            {
                return 0.5;
            }
        }

    }
}
