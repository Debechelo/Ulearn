using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Recognizer {
    public static class ThresholdFilterTask {
        public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction) {
            int width = original.GetLength(0);
            int height = original.GetLength(1);

            var list = SortTwoDimArrat(original);
            var countOfWhite = (int)(whitePixelsFraction * width * height);

            double treshold;
            if(countOfWhite == 0)
                treshold = int.MaxValue;
            else
                treshold = list[original.Length - countOfWhite];

            return FillByTreshold(original, treshold);
        }

        public static List<double> SortTwoDimArrat(double[,] original) {
            var list = new List<double>();

            int width = original.GetLength(0);
            int height = original.GetLength(1);
            for(var i = 0; i < width; i++)
                for(var j = 0; j < height; j++)
                    list.Add(original[i, j]);
            list.Sort();

            return list;
        }

        public static double[,] FillByTreshold(double[,] original, double treshold) {
            int width = original.GetLength(0);
            int height = original.GetLength(1);

            for(var i = 0; i < width; i++) {
                for(var j = 0; j < height; j++) {
                    if(original[i, j] >= treshold)
                        original[i, j] = 1;
                    else
                        original[i, j] = 0;
                }
            }
            return original;
        }
    }
}