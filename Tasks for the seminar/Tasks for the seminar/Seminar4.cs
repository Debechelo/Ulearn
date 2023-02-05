namespace Tasks_for_the_seminar;
internal class Seminar4 {

    /*
     * Найдите минимальную степень двойки, превосходящую заданное число.
     * Более формально: для заданного числа nn найдите минимальное целое x>nx>n, 
     * такое, что x=2kx=2k для некоторого целого, неотрицательного kk.
     * Решите эту задачу с помощью цикла while.
     */
    private static int GetMinPowerOfTwoLargerThan(int number) {
        int result = 1;
        while(result <= number) {
            result *= 2;
        }
        return result;
    }

    /* 
     * Враги вставили в начало каждого полезного текста целую кучу бесполезных пробельных символов!
     * Вася смог справиться с ситуацией, когда такой пробел был один, но продвинуться
     * дальше ему не удается. Помогите ему с помощью цикла while.
     */
    public static string RemoveStartSpaces(string text) {
        int i = 0;
        while(char.IsWhiteSpace(text[i])) {
            if(i == text.Length - 1)
                return "";
            i++;
        }
        return text.Substring(i++);
    }

    /*
     * Вы решили помочь Васе с разработкой его игры и взяли на себя красивый вывод сообщений в игре.
     * Напишите функцию, которая принимает на вход строку текста и печатает ее
     * на экран в рамочке из символов +, - и |. Для красоты текст должен 
     * отделяться от рамки слева и справа пробелом.
     * 
     * Например, текст Hello world должен выводиться так:
     *   +-------------+
     *   | Hello world |
     *   +-------------+
     */
    private static void WriteTextWithBorder(string text) {
        Console.Write("+");
        for(int i = 0; i < text.Length + 2; i++)
            Console.Write("-");
        Console.WriteLine("+");
        Console.WriteLine("| {0} |", text);
        Console.Write("+");
        for(int i = 0; i < text.Length + 2; i++)
            Console.Write("-");
        Console.WriteLine("+");
    }


    /*
     * Стали известны подробности про новую игру Васи. Оказывается ее действия
     * разворачиваются на шахматных досках нестандартного размера.
     * У Васи уже написан код, генерирующий стандартную шахматную доску
     * размера 8х8. Помогите Васе переделать этот код так, чтобы он умел 
     * выводить доску любого заданного размера.
     * 
     * Например, доска размера пять должна выводиться так:
     * 
     * #.#.#  
     * .#.#.  
     * #.#.#  
     * .#.#.  
     * #.#.#
     */
    private static void WriteBoard(int size) {
        for(int i = 0; i < size; i++) {
            for(int j = 0; j < size; j++) {
                if((i + j) % 2 == 0)
                    Console.Write("#");
                else
                    Console.Write(".");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    /*
     * Loops1. Дано целое неотрицательное число N. Найти число, составленное теми 
     * же десятичными цифрами, что и N, но в обратном порядке. Запрещено использовать массивы.
     */
    public static int Loops1(int number) {
        int result = 0;
        while(number > 0) {
            result *= 10;
            result += number % 10;
            number /= 10;
        }
        return result;
    }

    /* 
    * Loops2. Дано N (1 ≤ N ≤ 27). Найти количество трехзначных натуральных чисел, сумма цифр
    * которых равна N. Операции деления (/, %) не использовать.
    */

    public static int Loops2(int number) {
        int count = 0;
        int k1 = 1;
        int k2 = 0;
        int k3 = 0;
        while(true) {
            if(k1 + k2 + k3 == number)
                count++;

            k3++;
            if(k3 == number + 1 || k3 > 9) {
                k2++;
                k3 = 0;
                if(k2 == number + 1 || k2 > 9) {
                    k1++;
                    k2 = 0;
                    if(k1 == number + 1 || k1 > 9) {
                        break;
                    }
                }
            }
        }
        return count;
    }

    /*
    *Loops3. Если все числа натурального ряда записать подряд каждую цифру
    *в своей позиции, то необходимо ответить на вопрос: какая цифра стоит в заданной позиции N.
    */
    public static int Loops3(int N) {
        int count = 0;
        int index = 0;
        int k = 1;
        int x10 = 1;
        while(index < N) {
            count += 9 * x10;
            x10 *= 10;
            index += k * (x10 - x10 / 10);
            k++;
        }

        k--;
        index -= k * (x10 - x10 / 10);
        x10 /= 10;
        count -= 9 * x10;
        int l = ((N - index) / k);
        index += l * k;
        count += l;
        index -= N;

        for(int i = 0; i < index; i++) {
            count /= 10;
        }
        return count % 10;
    }


    /*
    *Loops4. В массиве чисел найдите самый длинный подмассив из одинаковых чисел.
    */

    public static int[] Loops4(int[] arr) {
        if(arr.Length == 0)
            return null;
        if(arr.Length == 1)
            return arr;

        int number = arr[0];
        int maxLen = 1;
        int len = 1;
        for(int i = 1; i < arr.Length; i++) {
            if(arr[i] == arr[i - 1]) {
                len++;
                if(maxLen < len) {
                    maxLen = len;
                    number = arr[i];
                }
            } else
                len = 1;
        }

        arr = new int[maxLen];
        for(int i = 0; i < arr.Length; i++) {
            arr[i] = number;
        }
        return arr;
    }

    /*
    *Loops5. Дана строка из символов '(' и ')'. Определить, является ли она
    *корректным скобочным выражением. Определить максимальную глубину вложенности скобок.
    */
    public static int Loops5(string str) {
        int open = 0;
        int maxDeep = 0;

        for(int i = 0; i < str.Length; i++) {
            if(str[i] == '(') 
                open++;
            else if(str[i] == ')')
                open--;
            if(open < 0)
                return -1;
            if(maxDeep < open)
                maxDeep = open;
        }
        return maxDeep;
    }
}
