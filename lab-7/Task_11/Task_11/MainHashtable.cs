using System;
using System.Collections.Generic;
using System.Text;

namespace Task_11
{
    public class MainHashtable
    {
        private KeyMainTable[] _keys;
        private ValueMainTable[] _table;
        private int _size;
        public string Loadness 
        {
            get 
            {
                double Percent;

                try
                {
                    Percent = Math.Round((double)_size / _table.Length,4);
                    if (Double.IsNaN(Percent)) throw new Exception();
                }
                catch (Exception)
                {
                    Percent = 0;
                }

                return new string($"----------------------------------- LOADNESS: {Percent * 100}% | {_size}/{_table.Length}  -----------------------------------\n");
            }
        }
        public MainHashtable() 
        {
            Array.Resize(ref _keys, 0);
            Array.Resize(ref _table, 0);
            _size = 0;
        }
        private int hashCode(KeyMainTable Key, int i, int ArrayLength) => ( Key.ID + i * i ) % ArrayLength;
        private int getHash(KeyMainTable key, ValueMainTable[] table)  
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
        private void Rehashing(ref ValueMainTable[] OldTable, ref KeyMainTable[] OldKeys)
        {
            ValueMainTable[] NewTable = new ValueMainTable[OldTable.Length * 2];
            KeyMainTable[] NewKeys = new KeyMainTable[OldKeys.Length * 2];

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
        private int FindEntry(KeyMainTable key)
        {
            if (_keys.Length == 0)
                return -1;

            int i = 0;
            int hash = hashCode(key, i, _keys.Length);
            while (i < _keys.Length) 
            {
                try
                {
                    if (_keys[hash].ID == key.ID)
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
        public void InsertEntry(EntryMainTable NewElement) 
        {
            if (_table.Length == 0)
            {
                Array.Resize(ref _table, 2);
                Array.Resize(ref _keys, 2);
            }

            KeyMainTable key = NewElement.key;
            ValueMainTable value = NewElement.value;

            if ((double)_size / _table.Length >= 0.5)
            {
                Console.WriteLine(Loadness);
                Console.WriteLine("----------------------------------- REHESHING... ------------------------------------------\n");
                Rehashing(ref _table, ref _keys);
                Console.WriteLine(Loadness);
            }
                

            int hash = getHash(key, _table);

            _table[hash] = value;
            _keys[hash] = key;
            _size++;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successfully added a new ticket: {_keys[hash]}, {_table[hash]}");
            Console.ForegroundColor = ConsoleColor.White;

        }
        public void RemoveEntry(KeyMainTable key) 
        {
            int hash = FindEntry(key);
            if (hash == -1) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Cant find ticket {key}");
                Console.ForegroundColor = ConsoleColor.White;
            } 
            else 
            {
                dynamic deletedValue = _table[hash];
                dynamic deletedKey = _keys[hash];

                _table[hash] = default;
                _keys[hash] = default;
                _size--;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Successfully deleted a ticket: {deletedKey}, {deletedValue}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public ValueMainTable GetInfo(KeyMainTable key) 
        {
            int hash = FindEntry(key);
            if (hash != -1) 
            {
                ValueMainTable value = _table[hash];
                return value;
            }

            return default;
        }
        public void ShowFindEntry(KeyMainTable key)
        {
            int hash = FindEntry(key);
            if (hash == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Cant find ticket {key}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"[{_keys[hash]}] | [{_table[hash]}]");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void ShowData() 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Loadness);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===================================== TABLE ===========================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var key in _keys) 
            {
                if (key != default) 
                {
                    int hash = FindEntry(key);
                    Console.WriteLine($"[{_keys[hash]}] | [{_table[hash]}]");

                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=======================================================================================");
        }
    }
}
