using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Image_Downsizer.Solvers
{
    public static class STSolver
    {

        public static void Solve(int percentage,Bitmap oldImage) 
        {
            var rect = new Rectangle(0, 0, oldImage.Width, oldImage.Height);
            BitmapData oldImagebitmapData = oldImage.LockBits(rect,ImageLockMode.ReadWrite,oldImage.PixelFormat);
            IntPtr oldImagePtr = oldImagebitmapData.Scan0;

            int bytes = Math.Abs(oldImagebitmapData.Stride) * oldImage.Height;
            byte[] bgrValues = new byte[bytes];

            Marshal.Copy(oldImagePtr, bgrValues, 0, bytes); // 3 bytes B0 G1 R2 

            oldImage.UnlockBits(oldImagebitmapData);

            Color[,] pixels = new Color[oldImage.Height, oldImage.Width + 1];
            int index = 0;
            for (int i = 0; i < oldImage.Height; i++)
            {
                for (int j = 0; j < oldImage.Width + (oldImage.Width%2); j++)
                {
                    pixels[i, j] = Color.FromArgb(255, bgrValues[index + 2], bgrValues[index + 1], bgrValues[index]); //-7 gb ram used! 
                    index += 3;
                }
            }
            Console.WriteLine();
            Color[,] pixelsForNewImage = DSAlgorithms.DownsizeMatrix(pixels, percentage); //ok

            Bitmap newImage = ColorMatrixToBitmap(pixelsForNewImage);

            newImage.Save("C:\\Downloads\\testST.jpg", ImageFormat.Jpeg);
            Console.WriteLine();
        }
        public static Bitmap ColorMatrixToBitmap(Color[,] colorMatrix)
        {
            int height = colorMatrix.GetLength(0);
            int width = colorMatrix.GetLength(1);

            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, bitmap.PixelFormat);

            IntPtr ptr = bmpData.Scan0;

            int bytes = Math.Abs(bmpData.Stride) * height;
            byte[] rgbValues = new byte[bytes];

            int index = 0;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    rgbValues[index++] = colorMatrix[y, x].B; 
                    rgbValues[index++] = colorMatrix[y, x].G;
                    rgbValues[index++] = colorMatrix[y, x].R;
                }
                index += bmpData.Stride - width * 3;
            }

            Marshal.Copy(rgbValues, 0, ptr, bytes);

            bitmap.UnlockBits(bmpData);

            return bitmap;
        }
        
    }
}
