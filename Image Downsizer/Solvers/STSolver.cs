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
            image.

            var rect = new Rectangle(0, 0, image.Width, image.Height);

            System.Drawing.Imaging.BitmapData bitmapData = image.LockBits(rect,System.Drawing.Imaging.ImageLockMode.ReadWrite,image.PixelFormat);
            IntPtr intPtr = bitmapData.Scan0;

            int bytes = Math.Abs(bitmapData.Stride) * image.Height;
            byte[] rgbValues = new byte[bytes];

            Color[] pixelsInARow = new Color[rgbValues.Count() / 3];

            Color[,] pixels = new Color[image.Height, image.Width + 1];

            System.Runtime.InteropServices.Marshal.Copy(intPtr, rgbValues, 0, bytes); // 3 bytes B0 G1 R2 

            
            for (int i = 0; i < rgbValues.Count()/3; i++)
            {
                Color pixel =  Color.FromArgb(255,rgbValues[i*3+2], rgbValues[i*3+1], rgbValues[i*3]);
                pixelsInARow[i] = pixel;
            }

            

            //for (int i = 0; i < image.Height; i++)
            //{
            //    for (int j = 0; j < image.Width+1; j++)
            //    {
            //        pixels[i,j] = pixelsInARow[index++];
            //    }
            //} 
            //___________________________TESTING SOME STUFF_______________________________________________________________________________________________

            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width + 1; j++)
                {
                    pixels[i, j] = Color.Black;
                }
            }

            int index = 0;
            for (int i = 0; i < image.Height; i++)
            {
                for (int j = 0; j < image.Width + 1; j++)
                {
                    pixelsInARow[index++] = pixels[i, j];
                }
            }

            for (int i = 0; i < pixelsInARow.Length; i++)
            {
                rgbValues[i*3] = pixelsInARow[i].B;
                rgbValues[i*3+1] = pixelsInARow[i].G;
                rgbValues[i*3+2] = pixelsInARow[i].R;
            }


            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, intPtr, bytes);
            image.UnlockBits(bitmapData);
            image.Save("C:\\Downloads\\test123.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


            Console.WriteLine();
        }
    }
}
