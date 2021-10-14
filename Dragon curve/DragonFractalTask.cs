
using System;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
			var random = new Random(seed);
			double x = 1.0, y = 0.0;
			for (int i = 0; i < iterationsCount; i++)
			{
				if (random.Next(10) % 2 == 1)
				{
					double x1 = (x * Math.Cos(Math.PI / 4) - y * Math.Sin(Math.PI / 4)) / Math.Sqrt(2);
					double y1 = (x * Math.Sin(Math.PI / 4) + y * Math.Cos(Math.PI / 4)) / Math.Sqrt(2);
					x = x1;
					y = y1;
				}
				else
				{
					double x1 = (x * Math.Cos(Math.PI / 4 * 3) - y * Math.Sin(Math.PI / 4 * 3)) / Math.Sqrt(2) + 1;
					double y1 = (x * Math.Sin(Math.PI / 4 * 3) + y * Math.Cos(Math.PI / 4 * 3)) / Math.Sqrt(2);
					x = x1;
					y = y1;
				}

				pixels.SetPixel(x, y);
			}
		}
	}
}
