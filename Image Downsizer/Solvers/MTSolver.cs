using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Image_Downsizer.Solvers
{
    public static class MTSolver
    {
        public static void Solve(int percentage, Bitmap oldImage)
        {
            var rect = new Rectangle(0, 0, oldImage.Width, oldImage.Height);
            BitmapData oldImagebitmapData = oldImage.LockBits(rect, ImageLockMode.ReadWrite, oldImage.PixelFormat);
            IntPtr oldImagePtr = oldImagebitmapData.Scan0;

            int bytes = Math.Abs(oldImagebitmapData.Stride) * oldImage.Height;
            byte[] bgrValues = new byte[bytes];

            Marshal.Copy(oldImagePtr, bgrValues, 0, bytes); // 3 bytes B0 G1 R2 

            oldImage.UnlockBits(oldImagebitmapData);

            int halfHeight = (oldImage.Height + oldImage.Height % 2) / 2;
            int halfWidth = (oldImage.Width + oldImage.Width % 2) / 2;

            Color[,] topLeftPixels = new Color[halfHeight, halfWidth];
            Color[,] topRightPixels = new Color[halfHeight, halfWidth];
            Color[,] bottomLeftPixels = new Color[halfHeight, halfWidth];
            Color[,] bottomRightPixels = new Color[halfHeight, halfWidth];

            int index = 0;
            for (int i = 0; i < oldImage.Height; i++)
            {
                for (int j = 0; j < oldImage.Width + (oldImage.Width % 2); j++)
                {
                    Color pixelColor = Color.FromArgb(255, bgrValues[index + 2], bgrValues[index + 1], bgrValues[index]);
                    if (i < halfHeight)
                    {
                        if (j < halfWidth)
                            topLeftPixels[i, j] = pixelColor;
                        else
                            bottomLeftPixels[i, j - halfWidth] = pixelColor;
                    }
                    else
                    {
                        if (j < halfWidth)
                            topRightPixels[i - halfHeight, j] = pixelColor;
                        else
                            bottomRightPixels[i - halfHeight, j - halfWidth] = pixelColor;
                    }
                    index += 3;
                }
            }
            
            Task<Color[,]> task1 = Task.Run(() => DSAlgorithms.DownsizeMatrix(topLeftPixels, percentage));
            Task<Color[,]> task2 = Task.Run(() => DSAlgorithms.DownsizeMatrix(topRightPixels, percentage));
            Task<Color[,]> task3 = Task.Run(() => DSAlgorithms.DownsizeMatrix(bottomLeftPixels, percentage));
            Task<Color[,]> task4 = Task.Run(() => DSAlgorithms.DownsizeMatrix(bottomRightPixels, percentage));

            Task.WaitAll(task1, task2, task3, task4);

            Color[,] combinedPixels = CombineArrays(task1.Result, task2.Result, task3.Result, task4.Result);

            Bitmap newImage = STSolver.ColorMatrixToBitmap(combinedPixels);

            newImage.Save("C:\\Downloads\\testMT.jpg", ImageFormat.Jpeg);
        }
        private static Color[,] CombineArrays(Color[,] topLeft,Color[,] topRight, Color[,] bottomLeft, Color[,] bottomRight)
        {
            int width = topLeft.GetLength(0) + topRight.GetLength(0);
            int height = topLeft.GetLength(1) + bottomLeft.GetLength(1);

            Color[,] combined = new Color[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x < topLeft.GetLength(0))
                    {
                        if (y < topLeft.GetLength(1))
                            combined[x, y] = topLeft[x, y];
                        else
                            combined[x, y] = bottomLeft[x, y - topLeft.GetLength(1)];
                    }
                    else
                    {
                        if (y < topRight.GetLength(1))
                            combined[x, y] = topRight[x - topLeft.GetLength(0), y];
                        else
                            combined[x, y] = bottomRight[x - topLeft.GetLength(0), y - topRight.GetLength(1)];
                    }
                }
            }

            return combined;
        }
    }
}
