using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reaction_Diffusion_Model
{
    public partial class Form1 : Form
    {
        

        Simulation simulator; // instance of Simulation. More or less a manager class. Runs everything.
        Graphics screen; // Graphics object used to draw the Bitmap to screen
        // Params
        double feedRate;
        double killRate;
        // true if simulation is created false if simulation is null
        bool created;
        // Algorithm
        ILaplacianFactory algorithm;
        // Brush
        IBrushFactory brush;

        public Form1()
        {
            InitializeComponent();
            // Creates the graphics object
            screen = CreateGraphics();
            created = false;
        }
        // used to create the simulation
        private void btnCreateGrid_Click(object sender, EventArgs e)
        {
            if (getLapFunc() == null || getBrush() == null)
            {
                MessageBox.Show("Please enter all variables before proceeding");
            }
            else {
                if (CheckTextBoxes())
                {
                    SetParamVariables();
                    simulator = new Simulation(screen, algorithm, brush, feedRate, killRate);
                    created = true;
                }
                else
                {
                    MessageBox.Show("Please enter valid values for feed and kill rates");
                }
            }
        }
        // Calls the simulations cycle method on each tick
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (created)
            {
                simulator.Cycle();
            }
            else
            {
                MessageBox.Show("Please create the grid first");
            }
        }
        // Toggles the timer on & off
        private void btnToggleTimer_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
            Console.WriteLine(timer1.Enabled);
        }
        // Used to get the correct Laplacian Factory
        public ILaplacianFactory getLapFunc()
        {
            ILaplacianFactory lapFunc = null;
            
            if (rdo_Lap_Convoltion.Checked)
            {
                lapFunc = new ConvolutionFunction();
            }
            if (rdo_Lap_Perpendicular.Checked)
            {
                lapFunc = new PerpendicularFunction();
            }
            if (rdo_Lap_Delta.Checked)
            {
                lapFunc = new DeltaFunction();
            }

            return lapFunc;
        }
        // Used to get the correct Brush Factory
        public IBrushFactory getBrush()
        {
            IBrushFactory brush = null;

            if (rdo_grayscale.Checked)
            {
                brush = new GrayScaleFactory();
            }
            if (rdo_sRainbow.Checked)
            {
                brush = new ShortRainbowFactory();
            }
            if (rdo_lRainbow.Checked)
            {
                brush = new LongRainbowFactory();
            }
            if (rdo_yellowToRed.Checked)
            {
                brush = new YellowToRedFactory();
            }
            return brush;
          
        }
        // Set the parameters at init
        public void SetParamVariables()
        {
            feedRate = Convert.ToDouble(tbFeed.Text);
            killRate = Convert.ToDouble(tbKill.Text);
            algorithm = getLapFunc();
            brush = getBrush();
        }
        // Checks that both feed and kill rates entered are valid
        public bool CheckTextBoxes()
        {
            double result;
            if (double.TryParse(tbFeed.Text, out result) && double.TryParse(tbKill.Text, out result))
            {
                return true;
            }
            return false;
        }
        // Used to quicky simulate without drawing to the screen every timer tick
        private void btnJump_Click(object sender, EventArgs e)
        {
            if (created)
            {
                simulator.QuickCycle();
            }
            else
            {
                MessageBox.Show("Please create the grid first");
            }            
        }
        // Used to save the bitmap
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (created)
            {
                simulator.SaveImage();
            }
            else
            {
                MessageBox.Show("Please create the grid first");
            }
        }
        // Used to automate through simulations
        private void btn_LargeSim_Click(object sender, EventArgs e)
        {
            AutomaticSimulation aSim = new AutomaticSimulation(screen);
            aSim.Run();
            Console.WriteLine("Finished Whole Sim");
        }
    }
}
