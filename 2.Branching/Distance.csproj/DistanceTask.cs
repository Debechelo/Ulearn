using System;
using System.Security.Authentication.ExtendedProtection;

namespace DistanceTask {
    public static class DistanceTask {
        // Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
        public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y) {
            double AK = Math.Sqrt(((x - ax) * (x - ax)) + ((y - ay) * (y - ay)));
            double BK = Math.Sqrt(((x - bx) * (x - bx)) + ((y - by) * (y - by)));
            double AB = Math.Sqrt(((ax - bx) * (ax - bx)) + ((ay - by) * (ay - by)));
            if(AB == 0) {
                return BK;
            } else if(Math.Acos((AB * AB + BK * BK - AK * AK)
                / (2 * AB * BK)) >= Math.PI / 2) {
                return BK;
            } else if(Math.Acos((AB * AB + AK * AK - BK * BK)
                / (2 * AB * AK)) >= Math.PI / 2) {
                return AK;
            } else {
                return Math.Abs((by - ay) * x - (bx - ax) * y + bx * ay - by * ax)
                    / Math.Sqrt(((bx - ax) * (bx - ax)) + ((by - ay) * (by - ay)));
            }
        }
    }
}