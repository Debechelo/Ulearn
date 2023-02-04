internal class Program {
    private static void Main(string[] args) {
        string userInput = Console.ReadLine();
        double sum= Calculate(userInput);
        Console.WriteLine(sum);
    }

    /// <param name="userInput">Tри числа через пробел: исходная сумма, процентная ставка (в процентах)
    /// и срок вклада в месяцах</param>
    /// <returns>Накопившееся сумма</returns>
    public static double Calculate(string userInput) {
        string[] num = userInput.Split(' ');
        double sum = double.Parse(num[0]);
        double percentages = double.Parse(num[1]);
        double mounts = double.Parse(num[2]);
        return sum * Math.Pow(1 + percentages / 12.0 / 100.0, mounts);
    }
}