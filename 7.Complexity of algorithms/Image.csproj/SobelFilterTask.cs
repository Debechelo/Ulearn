using System;

namespace Recognizer
{
    internal static class SobelFilterTask
    {
        public static double[,] SobelFilter(double[,] g, double[,] sx)
        {
            double[,] sy = Transposed(sx);
            var width = g.GetLength(0);
            var height = g.GetLength(1);
            var result = new double[width, height];
            var shift = sx.GetLength(0) / 2;
            
            for(int x = shift; x < width - shift; x++)
                for(int y = shift; y < height - shift; y++) {
                    var gx = Convolution(g, sx, x, y, shift);
                    var gy = Convolution(g, sy, x, y, shift);
                    result[x, y] = Math.Sqrt(gx * gx + gy * gy);
                     
                }

            return result;
        }

        public static double[,] Transposed(double[,] sx) {
            int width = sx.GetLength(0);
            int height = sx.GetLength(1);
            double[,] sy = new double[height, width];

            for(int i = 0; i < width; i++) {
                for(int j = 0; j < height; j++) {
                    sy[j, i] = sx[i, j];
                }
            }

            return sy;
        }

        public static double Convolution(double[,] g, double[,] s, int x, int y, int shift) {
            int width = s.GetLength(0);
            int height = s.GetLength(1);
            double conv = 0;

            for(int i = 0; i < width; i++) {
                for(int j = 0; j < height; j++) {
                    conv += s[i, j] * g[x + i - shift, y + j - shift];
                }
            }

            return conv;
        }
    }
}