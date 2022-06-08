using System;
using System.Collections.Generic;
using System.Text;

namespace Task_11
{
    public class AdditionalHashtable
    {
        private KeyAdditionalTable[] _keys;
        private List<Ticket>[] _table;
        private int _size;
        public AdditionalHashtable() 
        {
            Array.Resize(ref _keys, 0);
            Array.Resize(ref _table, 0);
            _size = 0;
        }
        private int hashCode(KeyAdditionalTable Key, int i, int ArrayLength) 
        {
            string HashString = Key.ToStringForHash().ToLower();
            ulong s = 0;
            for (int j = 0; j < HashString.Length; j++)
                s = s + (ulong)(HashString[j] * Math.Pow(27, HashString.Length - j - 1));

            int hash = (int)((s + Convert.ToUInt64(i * i)) % Convert.ToUInt64(ArrayLength)); 
            return hash;
        }
        private int getHash(KeyAdditionalTable key, List<Ticket>[] table)
        {
            int i = 0;
            int hash = hashCode(key, i, table.Length);
            while (table[hash] != default)
            {
                i++;
                hash = hashCode(key, i, table.Length);
            }

            return hash;
        }
        private int FindEntry(KeyAdditionalTable key)
        {
            if (_keys.Length == 0)
                return -1;

            int i = 0;
            int hash = hashCode(key, i, _keys.Length);
            while (i < _keys.Length)
            {
                try
                {
                    if (_keys[hash].ToStringForHash() == key.ToStringForHash())
                        return hash;
                    else
                    {
                        i++;
                        hash = hashCode(key, i, _keys.Length);
                    }

                }
                catch (Exception)
                {
                    i++;
                    hash = hashCode(key, i, _keys.Length);
                }
            }

            hash = -1;
            return hash;
        }
        private void Rehashing(ref List<Ticket>[] OldTable, ref KeyAdditionalTable[] OldKeys)
        {
            List<Ticket>[] NewTable = new List<Ticket>[OldTable.Length * 2];
            KeyAdditionalTable[] NewKeys = new KeyAdditionalTable[OldKeys.Length * 2];

            for (int i = 0; i < OldKeys.Length; i++)
            {
                if (OldKeys[i] != default)
                {
                    int NewHash = getHash(OldKeys[i], NewTable);
                    NewTable[NewHash] = OldTable[i];
                    NewKeys[NewHash] = OldKeys[i];
                }
            }
            OldTable = NewTable;
            OldKeys = NewKeys;
        }

        public void InsertEntry(KeyAdditionalTable key, Ticket value)
        {
            if (_table.Length == 0)
            {
                Array.Resize(ref _keys, 2);
                Array.Resize(ref _table, 2);
            }
            if ((double)_size / _table.Length >= 0.5)
                Rehashing(ref _table, ref _keys);

            int hash = FindEntry(key);
            if (hash == -1)
            {
                int newHash = getHash(key, _table);

                _table[newHash] = new List<Ticket> { value };
                _keys[newHash] = key;
                _size++;
            }
            else 
            {
                _table[hash].Add(value);
            }
        }
        public void UpdateEntry(KeyAdditionalTable key, Ticket value)
        {
            int hash = FindEntry(key);
            _table[hash].Add(value);
        }
        public void RemoveEntry(KeyAdditionalTable key, Ticket value)  
        {
            int hash = FindEntry(key);

            if (hash != -1) 
            {
                if (_table[hash].Count == 1)
                {
                    _table[hash] = default;
                    _keys[hash] = default;
                    _size--;
                }
                else
                {
                    for (int i = 0; i < _table[hash].Count; i++)
                    {
                        if (value.Equals(_table[hash][i]))
                        {
                            _table[hash].RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        public List<Ticket> GetAllTicketsForDate(KeyAdditionalTable key, Date date) 
        {
            int hash = FindEntry(key);
            if (hash == -1) return null;

            List<Ticket> arr = _table[hash]; 
            List<Ticket> ArrDate = new List<Ticket>();
            foreach (Ticket ticket in arr) 
            {
                if (date.Equals(ticket.date)) ArrDate.Add(ticket);
            }
            
            return ArrDate;
        }
    }
}
