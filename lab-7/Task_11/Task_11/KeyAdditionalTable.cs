using System;
using System.Collections.Generic;
using System.Text;

namespace Task_11
{
    public class KeyAdditionalTable
    {
        public string cinemaHall;
        public string movieTitle;
        public KeyAdditionalTable(string cinemaHall, string movieTitle) 
        {
            this.cinemaHall = cinemaHall;
            this.movieTitle = movieTitle;
        }
        public string ToStringForHash() 
        {
            return cinemaHall + movieTitle;
        }
    }
}
