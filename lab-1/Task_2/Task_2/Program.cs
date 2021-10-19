using System;
using static System.Math;
using static System.Console;


namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int d = 0, m = 0;
            try
            {
                Console.Write("Enter d: ");
                d = int.Parse(ReadLine());
                Console.Write("Enter m: ");
                m = int.Parse(ReadLine());
            }
            catch (Exception e) 
            {
                WriteLine("Incorrect data input format");
                return;
            }

            int[] days_in_month = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string[] day_of_week = new string[7] { "Понедiлок", "Вiвторок", "Середа", "Четвер", "П’ятниця", "Субота ", "Недiля" };


            if (m < 1 || m > 12) 
            {
                Write("Data is incorrect");
                return;
            }
            if (d < 1 || d > days_in_month[m - 1]) 
            {
                Write("Data is incorrect");
                return;
            }

            int month_current = 0;
            int day_current = 1;
            int day_of_week_current = 2;

            while ((day_current != d) || ((month_current + 1) != m)) 
            {
                day_current++;
                if (day_current > days_in_month[month_current]) 
                {
                    day_current = 1;
                    month_current++;
                }
                day_of_week_current++;
                if (day_of_week_current > 6) day_of_week_current = 0;
            }

            if (d < 10 && m < 10) WriteLine($"0{d}/0{m} - це {day_of_week[day_of_week_current]}");
            else if (d < 10 && m > 10) WriteLine($"0{d}/{m} - це {day_of_week[day_of_week_current]}");
            else if (d > 10 && m < 10) WriteLine($"{d}/0{m} - це {day_of_week[day_of_week_current]}");
            else WriteLine($"{d}/{m} - це {day_of_week[day_of_week_current]}");
        }
    }
}
