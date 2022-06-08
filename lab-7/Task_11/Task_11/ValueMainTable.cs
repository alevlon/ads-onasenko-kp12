using System;
using System.Collections.Generic;
using System.Text;

namespace Task_11
{
    public class ValueMainTable
    {
        public string movieTitle;
        public string cinemaHall;
        public Date date;
        public int seat;
        public ValueMainTable(string movieTitle, string cinemaHall, Date date, int seat) 
        {
            this.movieTitle = movieTitle;
            this.cinemaHall = cinemaHall;
            this.date = date;
            this.seat = seat;
        }
        public override string ToString()
        {
            return $"Cinema hall: {cinemaHall}, Movie title: {movieTitle}, Date: {date}, Seat: {seat}";
        }
    }
}
