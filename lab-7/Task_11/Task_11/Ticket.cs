using System;
using System.Collections.Generic;
using System.Text;

namespace Task_11
{
    public class Ticket 
    {
        public Date date { get; set; }
        public int seat { get; set; }
        public Ticket(Date date, int seat) 
        {
            this.date = date;
            this.seat = seat;
        }

        public override bool Equals(object obj)
        {
            Ticket ticket = obj as Ticket;
            return ticket != null && ticket.date == date && ticket.seat == seat;
        }
    }
}
