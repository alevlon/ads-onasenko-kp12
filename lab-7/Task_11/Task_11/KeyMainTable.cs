using System;
using System.Collections.Generic;
using System.Text;

namespace Task_11
{
    public class KeyMainTable
    {
        public int ID;

        public KeyMainTable(string value)
        {
            this.ID = Convert.ToInt32(value);
        }
        public override string ToString()
        {
            return new string($"ID: {ID}");
        }
    }
}
