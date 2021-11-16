using System;
using static System.Math;
using static System.Console;
using System.Collections.Generic;

namespace lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0, m = 0;
            int i = 0, j = 0;
            int elemets = 0;

            int left = 0;
            int down = 0;
            int right = 0;
            int up = 0;
            

            List<int> i_of_max = new List<int>();
            List<int> j_of_max = new List<int>();
            try
            {
                Write("Enter n: "); n = int.Parse(ReadLine());
                if (n < 0) throw new Exception("Input string was not in a correct format.");

                Write("Enter m: "); m = int.Parse(ReadLine());
                if (m < 0) throw new Exception("Input string was not in a correct format.");
            }
            catch (Exception e) 
            {
                WriteLine($"{e.Message}");
                return;
            }

            int[,] arr = new int[n, m];

            try {

                int a = 0;
                Write("Enter 1, if you want to generate a random matrix, or 2 for use of a control example: ");
                a = int.Parse(ReadLine());


                if (a < 0 || a > 2) throw new Exception("Input string was not in a correct format.");

                if (a == 1)
                {
                    Random rdn = new Random();

                    for (i = 0; i < n; i++)
                    {
                        for (j = 0; j < m; j++)
                        {
                            arr[i, j] = rdn.Next(0, 20);
                        }
                    }
                }
                else if (a == 2) 
                {
                    int check = 0;
                    for (i = 0; i < n; i++)
                    {
                        for (j = 0; j < m; j++)
                        {
                            arr[i, j] = check;
                            check++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                WriteLine($"{e.Message}");
                return;
            }



            WriteLine("=================== The mass is  ===================");
            for (int k = 0; k < n; k++)
            {
                for (int f = 0; f < m; f++)
                {
                    Write(arr[k, f] + "\t");
                }

                WriteLine();
            }
            WriteLine("=================== The sequence is  ===================\n");




            j = m - 1;
            i = 0;
            while (elemets < m * n) 
            {
                int current_max = int.MinValue;
                int i_max = -1; int j_max = -1;
                while (j >= down)
                {
                    Write(arr[i, j] + " ");
                    if (arr[i, j] > current_max)
                    {
                        current_max = arr[i, j];
                        i_max = i + 1;
                        j_max = j + 1;
                    }
                    elemets++;  
                    j--;
                }
                j++;
                i++;
                i_of_max.Add(i_max);
                j_of_max.Add(j_max);
                left++;


                while (i <= n - right - 1)
                {
                    Write(arr[i, j] + " ");
                    elemets++;
                    i++;
                }
                i--;
                j++;
                down++;

                while (j <= m - up - 1)
                {
                    Write(arr[i, j] + " ");
                    elemets++;
                    j++;
                }
                j--;
                i--;
                right++;

                while (i >= left + 1)
                {
                    Write(arr[i, j] + " ");
                    elemets++;
                    i--;
                }
                up++;
                if (elemets == m * n - 1) 
                {
                    Write(arr[i, j] + " ");
                    break;
                }
            }
            WriteLine("\n");

            WriteLine("=================== The index of max elements is  ===================");
            for (int k = 0; k < i_of_max.Count; k++) 
            {
                WriteLine($"({i_of_max[k]}, {j_of_max[k]}) - {arr[i_of_max[k] - 1, j_of_max[k] - 1]}");
            }
        }
    }
}
