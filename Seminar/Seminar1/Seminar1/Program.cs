internal class Program {
    private static void Main(string[] args) {
        Console.WriteLine(Expr1(2, 3));
        Console.WriteLine(Expr2(243));
        Console.WriteLine(Expr3(8));
        Console.WriteLine(Expr4(90, 3, 2));
        Console.WriteLine(Expr5(1206, 1873));
        Console.WriteLine(Expr6(0, 0, 2, 0, 0, 4));
        Console.WriteLine(Expr7a(1, 3, 2));
        Console.WriteLine(Expr7b(1, 3, 2));
        Console.WriteLine(Expr8(1, 2, 3, 0, 0));
    }

    /*
     * Expr1. Как поменять местами значения двух переменных? 
     * Можно ли это сделать без ещё одной временной переменной.
     * Стоит ли так делать?
     */
    private static (int, int) Expr1(int a, int b) {
        return (b, a);

        a = a + b;
        b = b - a;
        a = a - b;
    }

    /*
     * Expr2. Задается натуральное трехзначное число (гарантируется, что трехзначное).
     * Развернуть его, т.е. получить трехзначное число, 
     * записанное теми же цифрами в обратном порядке.
    */
    private static int Expr2(int b) {
        return b % 10 % 10 * 100 + b / 10 % 10 * 10 + b / 100;
    }

    /*
     *Expr3. Задано время Н часов (ровно). Вычислить угол в градусах между часовой
     *и минутной стрелками. Например, 5 часов -> 150 градусов, 20 часов -> 120 градусов.
     *Не использовать циклы.
    */
    private static int Expr3(int hour) {
        hour = hour % 12 * 30;
        return hour < 7 ? hour : 360 - hour;
    }

    /*
     * Expr4. Найти количество чисел меньших N, которые имеют простые делители X или Y.
     */
    private static int Expr4(int N, int y, int x) {
        return (N - 1) / (x * y);
    }

    /*
     * Expr5. Найти количество високосных лет на отрезке [a, b] не используя циклы.
     */
    private static int Expr5(int x, int y) {
        int xCount = (x / 4) - (x / 100) + (x / 400);
        int yCount = (y / 4) - (y / 100) + (y / 400);

        return yCount - xCount;
    }

    /*
     * Expr6. Посчитать расстояние от точки до прямой, заданной двумя разными точками.
     */
    private static double Expr6(int x0, int y0, int ax, int ay, int bx, int by) {
        int abx = bx - ax;
        int aby = by - ay;

        int bex = x0 - bx;
        int bey = y0 - by;

        //int aex = x0 - ax;
        //int aey = y0 - ay;

        //int abXbe = abx * bex + aby * bey;
        //int abXae = abx * aex + aby * aey;

        return Math.Abs(abx * bey - aby * bex) / Math.Sqrt(abx * abx + aby * aby);
    }


    /*
     * Expr7. Найти вектор, (a)параллельный прямой. (b)Перпендикулярный прямой.
     * Прямая задана коэффициентами уравнения прямой.
     */
    private static (int, int) Expr7a(int a, int b, int c) {
        return (b, -a);
    }
    private static (int, int) Expr7b(int a, int b, int c) {
        return (a, b);
    }

    /*
     * Expr8. Дана прямая L и точка A. Найти точку пересечения прямой L с перпендикулярной
     * ей прямой P, проходящей через точку A. Можете считать,
     * что прямая задана либо двумя точками, либо коэффициентами уравнения прямой — как вам удобнее.
     */
    private static (int, int) Expr8(int a, int b, int c, int x, int y) {
        int a1 = b;
        int b1 = -a;
        int c1 = a1 * x + b1 * y;
        int lx = (b * c1 - b1 * c) / (b1 * a - b * a1);
        int ly = (a * c - a * c1) / (a * b1 - a * b);
        return (lx, ly);
    }
}