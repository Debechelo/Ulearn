using System.Drawing;
using System.Runtime.Intrinsics.Arm;

namespace Tasks_for_the_seminar;
internal class Seminar2 {
    public static string GetMinX(int a, int b, int c) {
        if(a == 0 && b == 0)
            return c.ToString();
        if(a == 0)
            return "Impossible";
        return (-(double)b / (double)(2 * a)).ToString();
    }

    /*
     *Expr10. Найти сумму всех положительных чисел меньше 1000 кратных 3 или 5.
     */
    public static int Expr10(int N, int x, int y) {
        int sum = 0;
        sum += ArithmeticProgression((N - 1) / x, x, x);
        sum += ArithmeticProgression((N - 1) / y, y, y);
        sum -= ArithmeticProgression((N - 1) / (x * y), x * y, x * y);
        return sum;
    }

    public static int ArithmeticProgression(int N, int a, int step) {
        return (2 * a + step * (N - 1)) * N / 2;
    }

    /*
     *Expr11. Дано время в часах и минутах. Найти угол от часовой к минутной стрелке на обычных часах.
     */
    public static int Expr11(int hour, int minute) {
        hour = hour % 12 * 30;
        minute = minute % 60 * 6;
        int angle = Math.Abs(hour - minute);
        return angle < 181 ? angle : 360 - angle;
    }

    /*
    *Expr12. 1885. Комфорт пассажиров.Самолёт должен набрать высоту h метров в 
    *течение первых t секунд полёта и удерживать её в течение всего полёта. 
    *Разрешён набор высоты со скоростью не более чем v метров в секунду. 
    *До полного набора высоты запрещено снижаться. Известно, что уши заложены в те и 
    *только те моменты времени, когда самолёт поднимается со скоростью более x метров в секунду. 
    *Посчитайте минимальное и максимальное возможное время, в течение которого у пассажиров будут заложены уши. 
    *Считайте, что самолёт способен изменять скорость мгновенно.
    */
    public static double Expr12Min(int h,int t, int v, int x) {
        if(x > v)
            return 0;
        //Console.WriteLine((h - x * t) / (v - x));
        //Console.WriteLine(h / t > x ? t : h / x);
        return (h - x * t) / (v - x);
    }

    public static double Expr12Max(int h, int t, int v, int x) {
        return h / t > x ? t : h / x;
    }

    /*
    *Expr13. 1084. Пусти козла в огород. Козла пустили в квадратный огород и привязали к колышку.
    *Колышек воткнули точно в центре огорода. Козёл ест всё, до чего дотянется, 
    *не перелезая через забор огорода и не разрывая веревку. 
    *Какая площадь огорода будет объедена? Даны длина веревки и размеры огорода.
    */
    public static double Expr13(int h, int r) {
        double s = Math.PI * r * r;
        if(r + r < h) {
            return s;
        } else if(r <= h * Math.Sqrt(2) / 2) {
            double O = 2 * Math.Acos(h / (2.0f * r));
            double sk = 2 * r * r * (O - Math.Sin(O));
            return s - sk;
        } else
            return h * h;           
    }
}
