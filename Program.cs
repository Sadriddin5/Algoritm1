using System;
using System.Linq;

public class ArrayMerger
{
    public static int[] MergeSort(int[] a, int[] b)
    {
        // Сортируем оба массива по убыванию перед слиянием
        Array.Sort(a, (x, y) => y.CompareTo(x));
        Array.Sort(b, (x, y) => y.CompareTo(x));

        int m = a.Length;
        int n = b.Length;
        int[] c = new int[m + n];

        int i = 0; // Указатель на первый элемент a (после сортировки по убыванию)
        int j = 0; // Указатель на первый элемент b (после сортировки по убыванию)
        int k = 0; // Указатель на текущий элемент c

        while (i < m && j < n)
        {
            if (a[i] > b[j])
            {
                c[k] = a[i];
                i++;
            }
            else
            {
                c[k] = b[j];
                j++;
            }
            k++;
        }

        // Копируем оставшиеся элементы (если есть)
        while (i < m)
        {
            c[k] = a[i];
            i++;
            k++;
        }
        while (j < n)
        {
            c[k] = b[j];
            j++;
            k++;
        }

        return c;
    }

    public static void Main(string[] args)
    {
        Random r = new Random();
        int length = r.Next(10, 100); // Определяем длину массива

        // Выделяем память под массивы
        int[] arr = new int[length];
        int[] arr2 = new int[length];

        for (int i = 0; i < length; i++)
        {
            arr[i] = r.Next(10, 100);
            arr2[i] = r.Next(10, 100);
        }

        int[] c = MergeSort(arr, arr2);

        if (c != null) //Проверка на null перед выводом
        {
            Console.WriteLine("Отсортированный по убыванию массив C:");
            Console.WriteLine(string.Join(", ", c));
        }
        else
        {
            Console.WriteLine("Один из массивов был null");
        }
    }
}
