using System;
using System.Collections.Generic;
using System.Text;

namespace Task_11
{
    public class EntryMainTable
    {
        public KeyMainTable key;
        public ValueMainTable value;
        public EntryMainTable(KeyMainTable key, ValueMainTable value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
