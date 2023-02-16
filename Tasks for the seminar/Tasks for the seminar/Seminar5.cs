using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks_for_the_seminar;
internal static class Seminar5 {
    /*
     * Arr1. Дан массив чисел. Нужно его сдвинуть циклически на K позиций влево,
     * не используя других массивов.
     */
    public static int[] Arr1(int[] array, int k) {
        int l1 = array[0], j = 0;
        int l2 = array[0];
        int el = array[0];
        for(int i = 0; i < array.Length; i++) {
            l1 = l2;
            j = (j + k) % array.Length;
            l2 = array[j];
            array[j] = l1;
        }
        return array;
    }

    /* 
     * Arr2. Даны два неубывающих массива чисел. Сформировать неубывающие массивы,
     * являющиеся объединением, пересечением и разностью этих двух массивов (разность в смысле мультимножеств).
     */
    public static List<int> Arr2Combin(int[] array1, int[] array2) {
        List<int> list = new List<int> ();
        int index1 = 0; 
        int index2 = 0;
        for(int i = 0; index1 < array1.Length && index2 < array2.Length; i++) {
            if(index1 == array1.Length) { 
                list.Add(array2[index2]);
                index2++;
            } else if(index2 == array2.Length) {
                list.Add(array1[index1]);
                index1++;
            } else if(array1[index1] < array2[index2]) {
                list.Add(array1[index1]);
                index1++;
            } else if(array1[index1] > array2[index2]) {
                list.Add(array2[index2]);
                index2++;
            } else {
                list.Add(array1[index1]);
                index1++;
                index2++;
            }
        }
        return list;
    }

    public static List<int> Arr2Intersection(int[] array1, int[] array2) {
        List<int> list = new List<int>();
        int index1 = 0;
        int index2 = 0;
        for(int i = 0; index1 < array1.Length && index2 < array2.Length; i++) {
            if(array1[index1] < array2[index2]) {
                index1++;
            } else if(array1[index1] > array2[index2]) {
                index2++;
            } else {
                list.Add(array1[index1]);
                index1++;
                index2++;
            }
        }
        return list;
    }

    public static List<int> Arr2Sub(int[] array1, int[] array2) {
        List<int> list = new List<int>();
        int index1 = 0;
        int index2 = 0;
        for(int i = 0; index1 < array1.Length && index2 < array2.Length; i++) {
            if(array1[index1] < array2[index2]) {
                list.Add(array1[index1]);
                index1++;
            } else if(array1[index1] > array2[index2]) {
                list.Add(array2[index2]);
                index2++;
            } else {
                index1++;
                index2++;
            }
        }
        return list;
    }

    /* 
     * Arr3. Перевести число из системы счисления с основанием A в систему с основанием B.
     * Можно считать, что 2 ≤ A, B ≤ 10, а число дано в виде массива цифр.
     */
    public static List<int> Arr3(int[] array, int A, int B) {
        List<int> arr = new List<int>();
        int k = 0;
        int l = 1;
        for(int i = array.Length - 1; i >= 0; i--) {
            k += array[i] * l;
            l *= A;
        }
        while(k !=0) {
            arr.Insert(0, k % B);
            k /= B;
        }
        return arr;
    }

    /* 
     * Arr4. Превратить рациональную дробь a/b (0 < a < b < 100000) в десятичную.
     * Возможен период. "1/6" должна превратиться в "0.1(6)"
     */
    public static string Arr4( int a, int b) {
        return (a/(double)b).ToString();
    }

    /* 
     * Arr5. * Дан неубывающий массив положительных целых чисел. 
     * Найти наименьшее положительное целое число, не представимое в виде суммы 
     * элементов этого массива (каждый элемент разрешается использовать в сумме только один раз).
     */
    public static int Arr5(int[] array) {
        List<int> list = new List<int>(array.Length);
        for(int i = 0; i < array.Length; i++) {
            int k = array[i];
            for(int j = i + 1; j < array.Length; j++) {
                if(k > 0)
                    list.Add(k);
                k += array[j];
            }
        }
        list.Sort();
        return list[0] - 1;
    }
}
