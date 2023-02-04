using System;

namespace DistanceTask {
    public static class DistanceTask {
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y) {
            double ak = GetVector(x, y, ax, ay);
            double kb = GetVector(x, y, bx, by);
            ;
            double ab = GetVector(ax, ay, bx, by);

            //скалярное произведение векторов
            double mulScalarAKAB = (x - ax) * (bx - ax) + (y - ay) * (by - ay);
            double mulScalarBKAB = (x - bx) * (-bx + ax) + (y - by) * (-by + ay);

            return FindDistance(ab, ak, kb, mulScalarAKAB, mulScalarBKAB);
        }

        private static double GetVector(double ax, double ay, double bx, double by) {
            return Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
        }

        private static double FindDistance(double ab, double ak, double kb, double mulScalarAKAB, double mulScalarBKAB) {
            if(ab == 0)
                return ak;
            else if(mulScalarAKAB >= 0 && mulScalarBKAB >= 0) {
                double p = (ak + kb + ab) / 2.0;
                double s = Math.Sqrt(Math.Abs((p * (p - ak) * (p - kb) * (p - ab))));

                return (2.0 * s) / ab;
            } else if(mulScalarAKAB < 0 || mulScalarBKAB < 0) {
                return Math.Min(ak, kb);
            } else
                return 0;
        }
    }
}