using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Image_Downsizer.Solvers
{
    public static class DSAlgorithms
    {
        internal static Color[,] DownsizeMatrix(Color[,] oldImage, int percentage)
        {

            Color[,] newImage = initNewImage(oldImage, percentage);

            for (int y = 0; y < newImage.GetLength(1); y++)
            {
                for (int x = 0; x < newImage.GetLength(0); x++)
                {
                    int startX = x * oldImage.GetLength(0) / newImage.GetLength(0);
                    int startY = y * oldImage.GetLength(1) / newImage.GetLength(1);
                    int endX = (x + 1) * oldImage.GetLength(0) / newImage.GetLength(0);
                    int endY = (y + 1) * oldImage.GetLength(1) / newImage.GetLength(1);


                    int totalR = 0, totalG = 0, totalB = 0; 
                    int count = 0;
                    for (int i = startX; i < endX; i++)
                    {
                        for (int j = startY; j < endY; j++)
                        {
                            totalR += oldImage[i, j].R;
                            totalG += oldImage[i, j].G;
                            totalB += oldImage[i, j].B;
                            count++;
                        }
                    }

                    byte avgR = (byte)(totalR / count);
                    byte avgG = (byte)(totalG / count);
                    byte avgB = (byte)(totalB / count);

                    newImage[x, y] = Color.FromArgb(avgR, avgG, avgB);
                }
            }

            return newImage;
        }
        private static Color[,] initNewImage(Color[,] pixels,int percentage)
        {
            int width = (int)Math.Ceiling(pixels.GetLength(0) * (percentage/100.0));
            int height = (int)Math.Ceiling(pixels.GetLength(1) * (percentage/100.0));
            if (percentage == 33)
            {
                width = (int)Math.Ceiling(pixels.GetLength(0) / 3.0);
                height = (int)Math.Ceiling(pixels.GetLength(1) / 3.0);
            }
            return new Color[width, height];
        }
    }
}
