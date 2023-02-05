using Tasks_for_the_seminar;

internal class Program {
    private static void Main(string[] args) {
        //SolvingTheTasksOfTheSeminar1();
        //SolvingTheTasksOfTheSeminar2();
        //SolvingTheTasksOfTheSeminar3();
        SolvingTheTasksOfTheSeminar4();
    }

    private static void SolvingTheTasksOfTheSeminar1() {
        Console.WriteLine(Seminar1.Expr1(2, 3));
        Console.WriteLine(Seminar1.Expr2(243));
        Console.WriteLine(Seminar1.Expr3(20));
        Console.WriteLine(Seminar1.Expr4(90, 3, 2));
        Console.WriteLine(Seminar1.Expr5(1206, 1873));
        Console.WriteLine(Seminar1.Expr6(0, 0, 2, 0, 0, 4));
        Console.WriteLine(Seminar1.Expr7a(1, 3, 2));
        Console.WriteLine(Seminar1.Expr7b(1, 3, 2));
        Console.WriteLine(Seminar1.Expr8(1, 2, 3, 0, 0));
    }

    private static void SolvingTheTasksOfTheSeminar2() {
        Console.WriteLine(Seminar2.Expr10(1000, 3, 5));
        Console.WriteLine(Seminar2.Expr11(8, 7));
        Console.WriteLine(Seminar2.Expr12Min(10000, 500, 50, 10));
        Console.WriteLine(Seminar2.Expr12Max(10000, 500, 50, 25));
        Console.WriteLine(Seminar2.Expr13(10, 6));
    }

    private static void SolvingTheTasksOfTheSeminar3() {
        Console.WriteLine(Seminar3.Cond1Bishop("a1", "b2"));
        Console.WriteLine(Seminar3.Cond2(4, 90, 6, 8, 5));
        Console.WriteLine(Seminar3.Cond3(184129));
        Console.WriteLine(Seminar3.Cond4(0, 70, 50, 60));
        Console.WriteLine(Seminar3.Cond5(72, 44, 3));
        Console.WriteLine(Seminar3.Cond5(32, 30, 7));
        Console.WriteLine(Seminar3.Cond5(97, 32, 9));
        Console.WriteLine(Seminar3.Cond5(26, 13, 5));
        Console.WriteLine(Seminar3.Cond5(36, 4, 3));
        Console.WriteLine(Seminar3.Cond5(46, 38, 5));
        Console.WriteLine(Seminar3.Cond5(68, 41, 3));
        Console.WriteLine(Seminar3.Cond5(35, 12, 1));
        Console.WriteLine(Seminar3.Cond6((0, 0), (1, 1), (2, 2)));
        Console.WriteLine(Seminar3.Cond7(12, 9.5, 2.0));
    }

    private static void SolvingTheTasksOfTheSeminar4() {
        Console.WriteLine(Seminar4.Loops1(12345));
        Console.WriteLine(Seminar4.Loops2(27));
        Console.WriteLine(Seminar4.Loops3(17));
        Console.WriteLine(Seminar4.Loops4(new int[] { 3, 1, 1, 1, 1, 1, 5, 1, 1, 1, 4 }));
        Console.WriteLine(Seminar4.Loops5("()(((()()))(()))()"));
    }
}