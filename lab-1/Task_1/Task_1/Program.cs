using System;
using static System.Math;
using static System.Console;


namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0, y = 0, z = 0;
            try
            {
                Write("x = ");
                x = double.Parse(ReadLine());

                Write("y = ");
                y = double.Parse(ReadLine());

                Write("z = ");
                z = double.Parse(ReadLine());
            }
            catch (Exception e) 
            {
                WriteLine("Incorrect data input format");
                return;
            }
            


            if (z == 0)
            {
                WriteLine("Data is incorrect");
            }
            else 
            {
                double a = Cos(x + x * y / z);
                double cos_a = Cos(a);
                if (cos_a == 0)
                {
                    WriteLine("Data is incorrect");
                }
                else 
                {
                    double b = Pow(x, 3) / cos_a;

                    WriteLine($"a = {a}");
                    WriteLine($"b = {b}");
                }
            }
        }
    }
}
