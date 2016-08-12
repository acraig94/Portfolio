using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Reaction_Diffusion_Model
{
    public class SaveBitmap
    {
        string filename;

        public SaveBitmap(double feedRate, double killRate, ILaplacianFactory a)
        {
            string feed = Convert.ToString(feedRate);
            string kill = Convert.ToString(killRate);
            filename = "pattern_" + feedRate + "_" + kill + "_" + LaplacianString(a);
        }
        // Used to create a string associated with the Laplacian function
        public String LaplacianString(ILaplacianFactory a)
        {
            if (a is PerpendicularFunction)
            {
                return "P";
            }
            else if (a is ConvolutionFunction)
            {
                return "C";
            }
            else
            {
                return "D";
            }
        }
        // Saves Bitmap as an image
        public void SaveCanvas(Bitmap bitmap)
        {
            string appPath = @"Images\";
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            try
            {
                bitmap.Save(appPath + filename + ".bmp", ImageFormat.Bmp);
            }
            catch (Exception e)
            {
                MessageBox.Show("error saving file. " + e.Message);
            }


        }

    }
}
