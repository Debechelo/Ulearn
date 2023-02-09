using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Recognizer
{
	internal static class MedianFilterTask
	{
        /* 
		 * Для борьбы с пиксельным шумом, подобным тому, что на изображении,
		 * обычно применяют медианный фильтр, в котором цвет каждого пикселя, 
		 * заменяется на медиану всех цветов в некоторой окрестности пикселя.
		 * https://en.wikipedia.org/wiki/Median_filter
		 * 
		 * Используйте окно размером 3х3 для не граничных пикселей,
		 * Окно размером 2х2 для угловых и 3х2 или 2х3 для граничных.
		 */
        public static double[,] MedianFilter(double[,] original) {
            int width = original.GetLength(0);
            int height = original.GetLength(1);
            double[,] original2 = new double[width, height];

            List<double> pixels;

            for(int i = 0; i < width; i++)
                for(int j = 0; j < height; j++) {
                    pixels = CheckAround(original, width, height, i, j);
                    pixels.Sort();
                    int pixs = pixels.Count;
                    original2[i, j] = pixs % 2 == 1 ? pixels[pixs / 2]
                        : (pixels[pixs / 2] + pixels[pixs / 2 - 1]) / 2;
                    pixels.Clear();
                }
            return original2;
        }

        public static List<double> CheckAround(double[,] original,
            int width, int height, int i, int j) {
            List<double> list = new List<double>(9);

            list.Add(original[i, j]);
            if(i - 1 >= 0)
                list.Add(original[i - 1, j]);
            if(i + 1 < width)
                list.Add((original[i + 1, j]));
            if(j - 1 >= 0)
                list.Add(original[i, j - 1]);
            if(j + 1 < height)
                list.Add(original[i, j + 1]);
            if(i - 1 >= 0 && j - 1 >= 0)
                list.Add(original[i - 1, j - 1]);
            if(i + 1 < width && j - 1 >= 0)
                list.Add(original[i + 1, j - 1]);
            if(i - 1 >= 0 && j + 1 < height)
                list.Add(original[i - 1, j + 1]);
            if(i + 1 < width && j + 1 < height)
                list.Add(original[i + 1, j + 1]);

            return list;
        }
    }
}