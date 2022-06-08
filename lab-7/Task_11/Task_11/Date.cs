using System;
using System.Collections.Generic;
using System.Text;

namespace Task_11
{
    public class Date
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public Date(int year, int month, int day) 
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }
        public override string ToString()
        {
            return $"{Day}.{Month}.{Year}";
        }
        public override bool Equals(object obj)
        {
            Date date = obj as Date;
            return date != null && date.Year == this.Year && date.Month == this.Month && date.Day == this.Day;
        }
    }
}
