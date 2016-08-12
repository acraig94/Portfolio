using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reaction_Diffusion_Model;
using System.Drawing;
using System.Windows.Forms;

namespace Reaction_Diffusion_Model_Testing
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void CheckConcentrationBoundries_GreaterThan1_Returns1()  
        {
            Control control = new Control();
            Graphics g = control.CreateGraphics();
            DrawManager dm = new DrawManager(g, 0, 0);
            IBrushFactory brush = new GrayScaleFactory();
            ILaplacianFactory lap = new PerpendicularFunction();
            Cell cell = new Cell(dm, brush, new Point(0,0), 2, lap, 0.00002, 0.00001, 0.025, 0.056);

            double test = cell.CheckConcentrationBoundries(2);

            double expected = 1.0;

            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void CheckConcentrationBoundries_LessThan0_Returns0()
        {
            Control control = new Control();
            Graphics g = control.CreateGraphics();
            DrawManager dm = new DrawManager(g, 0, 0);
            IBrushFactory brush = new GrayScaleFactory();
            ILaplacianFactory lap = new PerpendicularFunction();
            Cell cell = new Cell(dm, brush, new Point(0, 0), 2, lap, 0.00002, 0.00001, 0.025, 0.056);

            double test = cell.CheckConcentrationBoundries(-1);

            double expected = 0.0;

            Assert.AreEqual(expected, test);
        }

        [TestMethod]
        public void CheckConcentrationBoundries_BetweenBoundraies_Returnsx()
        {
            Control control = new Control();
            Graphics g = control.CreateGraphics();
            DrawManager dm = new DrawManager(g, 0, 0);
            IBrushFactory brush = new GrayScaleFactory();
            ILaplacianFactory lap = new PerpendicularFunction();
            Cell cell = new Cell(dm, brush, new Point(0, 0), 2, lap, 0.00002, 0.00001, 0.025, 0.056);

            double x = 0.5;
            double test = cell.CheckConcentrationBoundries(x);

            double expected = 0.5;

            Assert.AreEqual(expected, test);
        }

    }
}
