using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Downsizer
{
    public static class STSolver
    {

        public static void Solve(int percentage,Bitmap image) 
        {
            var rect = new Rectangle(0, 0, image.Width, image.Height);

            System.Drawing.Imaging.BitmapData bitmapData = image.LockBits(rect,System.Drawing.Imaging.ImageLockMode.ReadWrite,image.PixelFormat);
            IntPtr intPtr = bitmapData.Scan0;

            int bytes = Math.Abs(bitmapData.Stride) * image.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(intPtr, rgbValues, 0, bytes); // 3 bytes B0 G1 R2 

            Color[] pixels = new Color[rgbValues.Count()/3];
            for (int i = 0; i < rgbValues.Count()/3; i++)
            {
                Color pixel =  Color.FromArgb(255,rgbValues[i*3+2], rgbValues[i*3+1], rgbValues[i*3]);
                pixels[i] = pixel;
            }
            Console.WriteLine();
        }
    }
}
