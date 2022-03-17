using System;
using static System.Console;
using System.Collections.Generic;

namespace Task_15
{
    class Program
    {
        static void Main(string[] args)
        {
            int N, M, K;
            List<int> multiple_k = new List<int>();
            List<int> not_multiple_k = new List<int>();
            try
            {
                Write("Enter the M: ");
                M = int.Parse(ReadLine());
                if (M < 1) throw new Exception("Invalid input");

                Write("Enter the N: ");
                N = int.Parse(ReadLine());
                if (N < 1) throw new Exception("Invalid input");

                Write("Enter the K: ");
                K = int.Parse(ReadLine());
                if (K < 1) throw new Exception("Invalid input");

                Write("Enter 1, if you want to generate random elements\nEnter 2, if you want to use test case: ");
                int a = int.Parse(ReadLine());
                if (a < 0 || a > 2) throw new Exception("Invalid input");

                int[,] arr = new int[N, M];
                if (a == 1)
                {
                    Random rnd = new Random();
                    for (int i = 0; i < N; i++)
                    {
                        for (int j = 0; j < M; j++)
                        {
                            int x = rnd.Next(-999, 999);
                            while (Сheck_Uniq(arr, N, M, x) == false) x = rnd.Next(-999, 999);

                            arr[i, j] = x;
                        }
                    }
                }
                else 
                {
                    int x = 1;
                    for (int i = 0; i < N; i++) 
                    {
                        for (int j = 0; j < M; j++) 
                        {
                            arr[i, j] = x;
                            x++;
                        }
                    }
                }
                PrintAndSaveData(arr, N, M, K, multiple_k, not_multiple_k);

                if (multiple_k.Count < M)
                {
                    SortInsert(multiple_k);
                    multiple_k.Reverse();
                }
                else 
                {
                    QuickSort(multiple_k, 0, multiple_k.Count - 1);
                    multiple_k.Reverse();
                }

                if (not_multiple_k.Count < M) SortInsert(not_multiple_k);
                else QuickSort(not_multiple_k, 0, not_multiple_k.Count - 1);


                int kef_multiple_k = 0;
                int kef_not_multiple_k = 0;
                WriteLine("\n=================== The sorted array is  ===================\n");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (arr[i, j] % K == 0)
                        {
                            Write(" ");
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.White;
                            Write(" " + multiple_k[kef_multiple_k] + " ");
                            Console.ResetColor();
                            Write(" ");

                            kef_multiple_k++;
                        }
                        else
                        {
                            Write(" ");
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.ForegroundColor = ConsoleColor.White;
                            Write(" " + not_multiple_k[kef_not_multiple_k] + " ");
                            Console.ResetColor();
                            Write(" ");

                            kef_not_multiple_k++;
                        }
                    }
                    WriteLine();
                }


            }
            catch (Exception e)
            {
                WriteLine(e.Message);
                return;
            }

        }

        public static void PrintAndSaveData(int[,] arr, int n, int m, int k, List<int> multiple_k, List<int> not_multiple_k) 
        {
            WriteLine("\n=================== The unsorted array is  ===================\n");
            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < m; j++) 
                {
                    if (arr[i, j] % k == 0)
                    {
                        Write(" ");
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.White;
                        Write(" " + arr[i, j] + " ");
                        Console.ResetColor();
                        Write(" ");

                        multiple_k.Add(arr[i, j]);
                    }
                    else 
                    {
                        Write(" ");
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Write(" " + arr[i, j] + " ");
                        Console.ResetColor();
                        Write(" ");

                        not_multiple_k.Add(arr[i, j]);
                    }
                }
                WriteLine();
            }
        }
        public static bool Сheck_Uniq(int[,] arr, int n, int m, int x)
        {
            bool check = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (x == arr[i, j]) check = false;
                }
                if (check == false) break;
            }

            return check;
        }
        public static void SortInsert(List<int> arr) //сортування вставкою
        {
            for (int i = 1; i < arr.Count; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while ((j >= 0) && (arr[j] > key))
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }
        }
        public static void QuickSort(List<int> arr, int low, int high) //Швидке сортування (розбиття Ломуто)
        {
            if (low >= high) return;

            int h = PartitionLomuto(arr, low, high);
            QuickSort(arr, low, h - 1);
            QuickSort(arr, h + 1, high);
        }
        public static int PartitionLomuto(List<int> arr, int low, int high) 
        {
            int pivot = arr[high];
            int i = low;
            for (int j = low; j <= high - 1; j++) 
            {
                if (arr[j] <= pivot) 
                {
                    Swap(arr, i, j);
                    i++;
                }
            }
            Swap(arr, i, high);
            return i;
        }   
        public static void Swap(List<int> arr, int i, int j) 
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
