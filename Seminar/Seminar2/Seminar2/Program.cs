internal class Program {
    private static void Main(string[] args) {
        Console.WriteLine("Hello, World!");
    }

    // функции, определяющей, является ли год високосным,
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
    public static bool Cond5(int x, int y, int z, int a, int b) {
        return (x <= a && y <= b) || (x <= b && y <= a)
                || (x <= a && z <= b) || (x <= b && z <= a)
                || (z <= a && y <= b) || (z <= b && y <= a);
    }

    /*
     * Cond6. * Заданы координаты трех точек на плоскости.
     * Являются ли они вершинами квадрата? Если да, то найти координаты четвертой вершины.
     */


    /*
     * Cond7. ** (1484. Кинорейтинг)
     * На сайте за фильм проголосовало N человек, каждый поставил оценку от 1 до 10.
     * Сейчас рейтинг фильма равен X (рейтинг — средняя оценка, округлённая до десятых 
     * по математическим правилам, цифра 5 всегда округляется вверх). 
     * Сколько минимум раз нужно поставить фильму оценку 1, чтобы его рейтинг гарантированно 
     * стал не выше Y? В решении нельзя использовать циклы.
     */
}