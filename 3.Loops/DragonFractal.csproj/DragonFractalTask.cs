// В этом пространстве имен содержатся средства для работы с изображениями. 
// Чтобы оно стало доступно, в проект был подключен Reference на сборку System.Drawing.dll
using System;
using System.Drawing;

namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
            var random = new Random(seed);

			double x = 0.0, y = 1.0;
            double pi45 = Math.PI / 4.0;
            double pi135 = Math.PI * 3.0 / 4.0;
            for(int i = 0; i < iterationsCount; i++) {
                double x1 = x;
                double y1 = y;
                pixels.SetPixel(x, y);
                if(random.Next(2) == 0) {
					x = (x1 * Math.Cos(pi45) - y1 * Math.Sin(pi45)) / Math.Sqrt(2);
					y = (x1 * Math.Sin(pi45) + y1 * Math.Cos(pi45)) / Math.Sqrt(2);
				} else {
                    x = (x1 * Math.Cos(pi135) - y1 * Math.Sin(pi135)) / Math.Sqrt(2) + 1;
                    y = (x1 * Math.Sin(pi135) + y1 * Math.Cos(pi135)) / Math.Sqrt(2);
                }
                
            }

            /*
			Начните с точки (1, 0)
			Создайте генератор рандомных чисел с сидом seed
			
			На каждой итерации:

			1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:

				Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
				x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
				y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)

				Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
				x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
				y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)
		
			2. Нарисуйте текущую точку методом pixels.SetPixel(x, y)

			*/
        }
	}
}