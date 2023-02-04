using System;

namespace Rectangles {
    public static class RectanglesTask {
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2) {
            return r1.Left <= r2.Left + r2.Width && r2.Left <= r1.Left + r1.Width
                && r1.Top <= r2.Top + r2.Height && r2.Top <= r1.Top + r1.Height;
        }

        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2) {
            if(!AreIntersected(r1, r2))
                return 0;
            else
                return (Math.Min(r1.Left + r1.Width, r2.Left + r2.Width) - Math.Max(r1.Left, r2.Left))
                * (Math.Min(r1.Top + r1.Height, r2.Top + r2.Height) - Math.Max(r1.Top, r2.Top));
        }

        // Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
        // Иначе вернуть -1
        // Если прямоугольники совпадают, можно вернуть номер любого из них.
        public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2) {
            if(AreIntersected(r1, r2)) {
                if(IsRectangleInner(r1, r2))
                    return 1;
                else if(IsRectangleInner(r2, r1))
                    return 0;
            }
            return -1;
        }

        public static bool IsRectangleInner(Rectangle r1, Rectangle r2) {
            return (r1.Left + r1.Width >= r2.Left + r2.Width && r1.Top + r1.Height >= r2.Top + r2.Height)
                 && (r1.Left <= r2.Left && r1.Top <= r2.Top);
        }
    }
}