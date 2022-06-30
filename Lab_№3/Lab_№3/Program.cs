using System;
using static System.Console;
using System.Collections.Generic;

namespace Lab__3
{
    public class Program
    {
        static int n;
        static int GreedLength = 0;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            bool work = true;
            while (work) 
            {
                WriteLine("//Введіть 1, для роботи з алгоритмом Дейкстри\n" +
                   "//Введіть 2, для роботи з алгоритмом Літла\n" +
                   "//Введіть 3, для роботи з жадібним алгоритмом\n" +
                   "//Введіть 4, для завершення роботи\n");
                try
                {
                    int a = int.Parse(Console.ReadLine());
                    if (a < 1 || a > 4) throw new Exception();
                    switch (a) 
                    {
                        case 1: 
                            {
                                WriteLine("\n/Введіть 1, для контрольного прикладу\n/Введіть 2, для вашого варіанту\n");
                                int temp = int.Parse(ReadLine());
                                if (temp < 1 || temp > 2) throw new Exception();

                                if (temp == 1)
                                {
                                    n = 5;
                                    int inf = int.MaxValue;
                                    int[,] matrix =  {{ -1, 5, inf, 9, inf },
                                                      { 5, -1, inf, 15, inf },
                                                      { inf, inf, -1, 11, 5 },
                                                      { 9, 15, 11, -1, 17 },
                                                      { inf, inf, 5, 17, -1 }};

                                    WriteLine("\nВхідний граф згідно варіанту №16: ");
                                    int[] res = DijkstraAlg(1, matrix);

                                    for (int i = 0; i < res.Length; i++)
                                    {
                                        if (i == res.Length - 1) Write($"M{i + 1} = {res[i]}");
                                        else Write($"M{i + 1} = {res[i]}, ");
                                    }
                                }
                                else 
                                {
                                    Write("\nВведіть n: ");
                                    n = Convert.ToInt32(ReadLine());

                                    int[,] matrix = new int[n, n];
                                    string[] temp2;
                                    for (int i = 0; i < n; i++)
                                    {
                                        temp2 = ReadLine().Split(" ");

                                        for (int j = 0; j < n; j++)
                                            matrix[i, j] = Convert.ToInt32(temp2[j]);
                                    }

                                    Write("\nВведіть почакову позицію: ");
                                    int position = Convert.ToInt32(ReadLine());

                                    WriteLine("\nВхідний граф згідно вашого варіанту: ");
                                    int[] res = DijkstraAlg(position, matrix);

                                    for (int i = 0; i < res.Length; i++)
                                    {
                                        if (i == res.Length - 1) Write($"M{i + 1} = {res[i]}");
                                        else Write($"M{i + 1} = {res[i]}, ");
                                    }
                                }

                                ReadKey();
                                Clear();
                                break;
                            }
                        case 2:
                            {
                                WriteLine("\n/Введіть 1, для контрольного прикладу\n/Введіть 2, для вашого варіанту\n");
                                int temp = int.Parse(ReadLine());
                                if (temp < 1 || temp > 2) throw new Exception();

                                if (temp == 1)
                                {
                                    n = 7;
                                    int[,] matrix = {{-1, 15, 11, 2, 8, 6, 9},
                                                    { 15, -1, 4, 11, 6, 15, 7},
                                                    { 11, 4, -1, 14, 3, 9, 5},
                                                    { 2, 11, 14, -1, 16, 11, 9},
                                                    { 8, 6, 3, 16, -1, 5, 10},
                                                    { 6, 15, 9, 11, 5, -1, 4},
                                                    { 9, 7, 5, 9, 10, 4, -1}};

                                    WriteLine("\nВхідний граф згідно варіанту №16: ");
                                    for (int i = 0; i < n; i++)
                                    {
                                        for (int j = 0; j < n; j++)
                                        {
                                            if (j == n - 1)
                                            {
                                                if (matrix[i, j] == int.MaxValue) Write($"∞");
                                                else Write($"{matrix[i, j]}");
                                            }
                                            else
                                            {
                                                if (matrix[i, j] == int.MaxValue) Write($"∞,\t");
                                                else Write($"{matrix[i, j]},\t");
                                            }
                                        }
                                        WriteLine();
                                    }

                                    int routeLength = LitleAlg(matrix);
                                    PrintWay();
                                    WriteLine($"\nДовжина: {routeLength}");
                                }
                                else
                                {
                                    Write("\nВведіть n: ");
                                    n = Convert.ToInt32(ReadLine());

                                    int[,] matrix = new int[n, n];
                                    string[] temp2;
                                    for (int i = 0; i < n; i++)
                                    {
                                        temp2 = ReadLine().Split(" ");

                                        for (int j = 0; j < n; j++)
                                            matrix[i, j] = Convert.ToInt32(temp2[j]);
                                    }

                                    WriteLine("\nВхідний граф згідно вашого варіанту: ");
                                    for (int i = 0; i < n; i++)
                                    {
                                        for (int j = 0; j < n; j++)
                                        {
                                            if (j == n - 1)
                                            {
                                                if (matrix[i, j] == int.MaxValue) Write($"∞");
                                                else Write($"{matrix[i, j]}");
                                            }
                                            else
                                            {
                                                if (matrix[i, j] == int.MaxValue) Write($"∞,\t");
                                                else Write($"{matrix[i, j]},\t");
                                            }
                                        }
                                        WriteLine();
                                    }

                                    int routeLength = LitleAlg(matrix);
                                    PrintWay();
                                    WriteLine($"\nДовжина: {routeLength}");
                                }


                                ReadKey();
                                Clear();
                                break;
                            }
                        case 3:
                            {
                                WriteLine("\n/Введіть 1, для контрольного прикладу\n/Введіть 2, для вашого варіанту\n");
                                int temp = int.Parse(ReadLine());
                                if (temp < 1 || temp > 2) throw new Exception();

                                if (temp == 1)
                                {
                                    n = 7;
                                    int[,] matrix = {{-1, 15, 11, 2, 8, 6, 9},
                                                    { 15, -1, 4, 11, 6, 15, 7},
                                                    { 11, 4, -1, 14, 3, 9, 5},
                                                    { 2, 11, 14, -1, 16, 11, 9},
                                                    { 8, 6, 3, 16, -1, 5, 10},
                                                    { 6, 15, 9, 11, 5, -1, 4},
                                                    { 9, 7, 5, 9, 10, 4, -1}};

                                    WriteLine("\nВхідний граф згідно варіанту №16: ");
                                    string way = GreedAlg(1, matrix);

                                    WriteLine($"\nКінцевий шлях: {way}");
                                    WriteLine($"Довжина: {GreedLength}");

                                    GreedLength = 0;
                                }
                                else 
                                {
                                    Write("\nВведіть n: ");
                                    n = Convert.ToInt32(ReadLine());

                                    int[,] matrix = new int[n, n];
                                    string[] temp2;
                                    for (int i = 0; i < n; i++)
                                    {
                                        temp2 = ReadLine().Split(" ");

                                        for (int j = 0; j < n; j++)
                                            matrix[i, j] = Convert.ToInt32(temp2[j]);
                                    }

                                    Write("\nВведіть почакову позицію: ");
                                    int position = Convert.ToInt32(ReadLine());

                                    WriteLine("\nВхідний граф згідно вашого варіанту: ");
                                    string way = GreedAlg(position, matrix);

                                    WriteLine($"\nКінцевий шлях: {way}");
                                    WriteLine($"Довжина: {GreedLength}");

                                    GreedLength = 0;
                                }

                                ReadKey();
                                Clear();
                                break;
                            }
                        case 4:
                            {
                                work = false;
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                    ReadKey();
                    Clear();
                }
            }
        }

        static int[] DijkstraAlg(int startPoint, int[,] matrix) 
        {
            for (int i = 0; i < n; i++) 
            {
                for (int j = 0; j < n; j++) 
                {
                    if (j == n - 1)
                    {
                        if (matrix[i, j] == int.MaxValue) Write($"∞");
                        else Write($"{matrix[i, j]}");
                    }
                    else 
                    {
                        if (matrix[i, j] == int.MaxValue) Write($"∞,\t");
                        else Write($"{matrix[i, j]},\t");
                    }
                    
                }
                WriteLine();
            }

            int[] M = new int[n];
            int[] stableM = new int[n];

            for (int i = 0; i < M.Length; i++)
                M[i] = int.MaxValue;

            M[startPoint] = 0;
            for (int m = 0; m < n; m++)
            {
                for (int i = 0; i < n; i++) 
                {
                    if (i == startPoint) continue;

                    if (matrix[i, startPoint] != int.MaxValue &&
                        matrix[i, startPoint] != -1 &&
                        stableM[i] != 1)
                    {
                        int temp = M[startPoint];
                        if (temp == -1) temp = 0;

                        if (temp + matrix[i, startPoint] < M[i])
                            M[i] = temp + matrix[i, startPoint];
                    }
                }

                stableM[startPoint] = 1;

                int newTemp = int.MaxValue;
                int nextMarker = -1;
                for (int i = 0; i < n; i++)
                {
                    if (stableM[i] != 1)
                    {
                        if (M[i] < newTemp)
                        {
                            newTemp = M[i];
                            nextMarker = i;
                        }
                    }
                }
                startPoint = nextMarker;
            }
            return M;
        }
        static string GreedAlg(int startPoint, int[,] matrix) 
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == n - 1)
                    {
                        if (matrix[i, j] == int.MaxValue) Write($"∞");
                        else Write($"{matrix[i, j]}");
                    }
                    else
                    {
                        if (matrix[i, j] == int.MaxValue) Write($"∞,\t");
                        else Write($"{matrix[i, j]},\t");
                    }

                }
                WriteLine();
            }

            string way = $"{startPoint} - ";
            int forEnd = startPoint;

            int[,] newMatrix = new int[n, n];
            Array.Copy(matrix, newMatrix, n * n);

            startPoint--;
            for (int j = 0; j < n - 1; j++) 
            {
                int min = int.MaxValue;
                int newStartPoint = -1;
                for (int f = 0; f < n; f++) 
                {
                    if (newMatrix[startPoint, f] == -1) continue;

                    if (min > newMatrix[startPoint, f]) 
                    {
                        min = newMatrix[startPoint, f];
                        newStartPoint = f;
                    }
                }
                GreedLength += min;
                for (int i = 0; i < n; i++)
                {
                    newMatrix[startPoint, i] = int.MaxValue;
                    newMatrix[i, startPoint] = int.MaxValue;
                }

                way += $"{newStartPoint + 1} - ";
                startPoint = newStartPoint;
            }

            way += $"{forEnd}";
            GreedLength += matrix[startPoint, forEnd - 1];

            return way;
        }

        static List<int> Way = new List<int>();
        private static void PrintWay()
        {
            Write("\nКінцевий шлях: ");
            for (int i = 0; i < Way.Count; i++)
                Write(Way[i] + "-");
            Write(Way[0]);
        }
        static int LitleAlg(int[,] matrix) 
        {
            bool[] blocked = new bool[n];
            blocked[0] = true;
            int wayLength = int.MaxValue;
            return LittleAlgorytm(matrix, blocked, 0, 1, 0, wayLength);
        }
        private static int LittleAlgorytm(int[,] matrix, bool[] blocked, int current, int count, int length, int wayLength)
        {
            int temp2 = wayLength;
            if (count == n && matrix[current, 0] > 0)
            {
                wayLength = Math.Min(wayLength, length + matrix[current, 0]);
                if (temp2 != wayLength)
                {
                    Way.Remove(current + 1); 
                    Way.Add(current + 1);
                }
                return wayLength;
            }
            for (int i = 0; i < n; i++)
            {
                if (!blocked[i] && matrix[current, i] > 0)
                {
                    blocked[i] = true;
                    wayLength = LittleAlgorytm(matrix, blocked, i, count + 1, length + matrix[current, i], wayLength);
                    blocked[i] = false;
                }
            }
            if (temp2 != wayLength)
            {
                Way.Remove(current + 1); 
                Way.Add(current + 1);
            }
            return wayLength;
        }
    }
}
