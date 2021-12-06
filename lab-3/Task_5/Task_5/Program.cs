using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;

namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int i = 0, j = 0;

            try
            {
                Write("Enter n: "); n = int.Parse(ReadLine());
                if (n < 0) throw new Exception("Input string was not in a correct format.");

            }
            catch (Exception e)
            {
                WriteLine($"{e.Message}");
                return;
            }

            int[] arr = new int[n];
            Random rdn = new Random();
            for (i = 0; i < n; i++) arr[i] = rdn.Next(-100, 30);


            List<int> mass_for_sort = new List<int>();
            for (i = 0; i < n; i++)
            {
                if (arr[i] < 0 && arr[i] % 2 == 0) mass_for_sort.Add(Abs(arr[i]));
            }


            int d = mass_for_sort.Count / 2;
            while (d >= 1)
            {
                for (i = d; i < mass_for_sort.Count; i++)
                {
                    int current = mass_for_sort[i];
                    j = i;
                    while ((j >= d) && (mass_for_sort[j - d] > current))
                    {
                        int t = mass_for_sort[j];
                        mass_for_sort[j] = mass_for_sort[j - d];
                        mass_for_sort[j - d] = t;

                        j = j - d;
                    }
                }

                d = d / 2;
            }
            for (i = 0; i < mass_for_sort.Count; i++) mass_for_sort[i] *= -1;



            WriteLine("\n=================== The unsorted array is  ===================\n");
            for (i = 0; i < n; i++)
            {
                if (arr[i] < 0 && arr[i] % 2 == 0)
                {
                    Write(" " + arr[i] + " ");
                }
                else
                {
                    Write(" ");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Write(" " + arr[i] + " ");
                    Console.ResetColor();
                    Write(" ");
                }
            }
            WriteLine();

            int x = 0;
            WriteLine("\n=================== The sorted array is  ===================\n");
            for (i = 0; i < n; i++)
            {
                if (arr[i] < 0 && arr[i] % 2 == 0)
                {
                    Write(" " + mass_for_sort[x] + " ");
                    x++;
                }
                else
                {
                    Write(" ");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Write(" " + arr[i] + " ");
                    Console.ResetColor();
                    Write(" ");
                }
            }
            WriteLine();



        }
    }
}
