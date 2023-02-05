using System;
using System.Collections.Generic;

namespace Tasks_for_the_seminar;
internal class Seminar3 {
    public static bool IsLeapYear(int year) {
        return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
    }

    // код выбора средней оценки из трех по медиане
    public static int MiddleOf(int a, int b, int c) {
        if((a >= b && b >= c) || (c >= b && b >= a))
            return b;
        if((a >= c && c >= b) || (b >= c && c >= a))
            return c;
        return a;
    }

    /*
     * Cond1. Дана начальная и конечная клетки на шахматной доске.
     * Корректный ли это ход на пустой доске для: слона, коня, ладьи, ферзя, короля?
     */
    public static bool Cond1Bishop(string from, string to) {
        var dx = Math.Abs(to[0] - from[0]); //смещение фигуры по горизонтали
        var dy = Math.Abs(to[1] - from[1]); //смещение фигуры по вертикали
        return dx == dy && dx != 0 && dy != 0;
    }
    public static bool Cond1Horse(string from, string to) {
        var dx = Math.Abs(to[0] - from[0]);
        var dy = Math.Abs(to[1] - from[1]);
        return (dx == 1 && dy == 3) || (dx == 3 && dy == 1);
    }
    public static bool Cond1Rook(string from, string to) {
        var dx = Math.Abs(to[0] - from[0]);
        var dy = Math.Abs(to[1] - from[1]);
        return (dx == 0 && dy != 0) || (dy == 0 && dx != 0);
    }
    public static bool Cond1Queen(string from, string to) {
        var dx = Math.Abs(to[0] - from[0]);
        var dy = Math.Abs(to[1] - from[1]);
        return (dx == dy && dx != 0 && dy != 0) || (dx == 0 && dy != 0) || (dy == 0 && dx != 0);
    }
    public static bool Cond1King(string from, string to) {
        var dx = Math.Abs(to[0] - from[0]);
        var dy = Math.Abs(to[1] - from[1]);
        return (dx == 1 && dy == 0) || (dx == 0 && dy == 1) || (dx == 1 && dy == 1);
    }

    /*
     * Cond2. Пролезет ли брус со сторонами x, y, z в отверстие со сторонами a, b,
     * если его разрешается поворачивать на 90 градусов?
     */

    public static bool Cond2(int x, int y, int z, int a, int b) {
        return (x <= a && y <= b) || (x <= b && y <= a)
                || (x <= a && z <= b) || (x <= b && z <= a)
                || (z <= a && y <= b) || (z <= b && y <= a);
    }

    /*
     * Cond3. (1493. В одном шаге от счастья) Дан номер трамвайного билета,
     * в котором суммы первых трёх цифр и последних трёх цифр отличаются на 1
     * (но не сказано, в какую сторону). Правда ли,
     * что предыдущий или следующий билет счастливый?
     */
    public static bool Cond3(int number) {
        int firstThree = number / 1000;
        int secondThree = number % 1000;
        int sumFirst = firstThree / 100 + firstThree / 10 % 10 + firstThree % 10 % 10;
        return (sumFirst == SumThree(secondThree + 1)) || (sumFirst == SumThree(secondThree - 1));
    }
    public static int SumThree(int number) {
        return number / 100 + number / 10 % 10 + number % 10 % 10;
    }

    /*
     * Cond4. Пересечение двух отрезков [A,B] и [C,D] на числовой прямой.
     * Найти красивое решение, то есть наиболее ясное и краткое.
     */
    public static (int, int) Cond4(int A, int B, int C, int D) {
        if(B < C)
            return (1, -1);
        if(A > C)
            return (A, B);
        if(B > D)
            return (C, D);
        return (C, B);
    }

    /*
     * Cond5. (1740. А олени лучше)
     * Нужно проехать L километров так, чтобы любой отрезок 
     * пути длиной K километров (K ≤ L) проезжать ровно за H часов.
     * Какое минимальное и максимальное время для этого понадобится?
     */
    public static int Cond5(int l, int k, int h) {
        return (int)Math.Ceiling((l / (double)k)) * h;
    }

    /*
     * Cond6. * Заданы координаты трех точек на плоскости.
     * Являются ли они вершинами квадрата? Если да, то найти координаты четвертой вершины.
     */
    public static (int, int) Cond6((int, int) a, (int, int) b, (int, int) c) {
        (int, int) abVector = GetVector(a, b);
        (int, int) acVector = GetVector(a, c);
        (int, int) bcVector = GetVector(b, c);
        if(!ItsRectangle(abVector, acVector, bcVector)) {
            Console.Write("Не квадрат");
            return (0, 0);
        }

        (int, int) mid, point1, point2;
        if(GetDistanseVector(abVector) == GetDistanseVector(acVector)) {
            mid = a;
            point1 = b;
            point2 = c;
        } else if(GetDistanseVector(abVector) == GetDistanseVector(bcVector)) {
            mid = b;
            point1 = a;
            point2 = c;
        } else {
            mid = c;
            point1 = a;
            point2 = b;
        }

        (int, int) vector1 = GetVector(mid, point1);
        (int, int) vector2 = GetVector(mid, point2);

        return (mid.Item1 + vector1.Item1 + vector2.Item1, mid.Item2 + vector1.Item2 + vector2.Item2);
    }

    public static bool ItsRectangle((int, int) abVector, (int, int) acVector, (int, int) bcVector) {

        if(GetDistanseVector(abVector) != GetDistanseVector(acVector)
            && GetDistanseVector(abVector) != GetDistanseVector(bcVector)
            && GetDistanseVector(acVector) != GetDistanseVector(bcVector))
            return false;

        if(ScalarProduct(abVector, acVector) != 0 && ScalarProduct(abVector, bcVector) != 0
            && ScalarProduct(acVector, bcVector) != 0)
            return false;
        return true;
    }

    private static double GetDistanse((int, int) point1, (int, int) point2) {
        return Math.Sqrt((point1.Item1 - point2.Item1) * (point1.Item1 - point2.Item1)
            + (point1.Item2 - point2.Item2) * (point1.Item2 - point2.Item2));
    }
    private static double GetDistanseVector((int, int) vector) {
        return Math.Sqrt(vector.Item1 * vector.Item1 + vector.Item2 * vector.Item2);
    }

    private static (int, int) GetVector((int, int) point1, (int, int) point2) {
        return (point2.Item1 - point1.Item1, point2.Item2 - point1.Item2);
    }

    private static int ScalarProduct((int, int) vector1, (int, int) vector2) {
        return vector1.Item1 * vector2.Item1 + vector1.Item2 - vector2.Item2;
    }
    /*
     * Cond7. ** (1484. Кинорейтинг)
     * На сайте за фильм проголосовало N человек, каждый поставил оценку от 1 до 10.
     * Сейчас рейтинг фильма равен X (рейтинг — средняя оценка, округлённая до десятых 
     * по математическим правилам, цифра 5 всегда округляется вверх). 
     * Сколько минимум раз нужно поставить фильму оценку 1, чтобы его рейтинг гарантированно 
     * стал не выше Y? В решении нельзя использовать циклы.
     */

    public static int Cond7(int N, double X, double Y) {
        if (Y == 1) return 0;
        int count = (int)((Y - X) * N / (1 - Y));
        double O = Y;
        while(Math.Round(O) == Y) {
            count--;
            O = (X * N + count) / (N + count);
        }
        count++;
        return count;
    }

}
