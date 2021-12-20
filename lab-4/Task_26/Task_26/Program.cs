using System;
using static System.Console;

namespace Task_26
{
    class SLList
    {
        public Node head;
        public int Count;
        public class Node
        {
            public string data;
            public Node next;
            public Node(string data)
            {
                this.data = data;
            }
            public Node(string data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }

        public SLList(string data)
        {
            head = new Node(data);
            head.next = head;
            Count = 1;
        }
        public void AddFirst(string data) 
        {
            if (head == null) 
            {
                head = new Node(data);
                head.next = head;
                Count++;
                return;
            }
            Node current = head;
            while (current.next != head) current = current.next;
            Node new_head = new Node(data, head);

            current.next = new_head;
            head = new_head;
            Count++;
        }
        public void AddToPosition(string data, int position) 
        {
            if (head == null)
            {
                head = new Node(data);
                head.next = head;
                Count++;
                return;
            }

            if (position < 0 || position > Count + 1) return;

            if (position == 1) AddFirst(data);
            else if (position == Count + 1) AddLast(data);
            else 
            {
                int x = 1;

                Node current = head;
                while (x < position - 1) 
                {
                    current = current.next;
                    x++;
                }
               
                Node new_node = new Node(data, current.next);
                current.next = new_node;
            }
            Count++;
        }
        public void AddLast(string data) 
        {
            if (head == null)
            {
                head = new Node(data);
                head.next = head;
                Count++;
                return;
            }

            Node current = head;
            while (current.next != head) current = current.next;

            Node new_node = new Node(data, head);

            if (current == head) head.next = new_node;
            else current.next = new_node;
            Count++;
        }
        public void DeleteFirst() 
        {
            if (Count == 1)
            {
                head = null;
                Count = 0;
                return;
            }
            else if (Count == 0) return;

            Node tail = head;
            while (tail.next != head) tail = tail.next;

            head = head.next;
            tail.next = head;
            
            Count--;
        }
        public void DeleteFromPosition(int position) 
        {
            if (position < 0 || position > Count + 1) return;

            if (Count == 1)
            {
                head = null;
                Count = 0;
                return;
            }
            else if (Count == 0) return;


            if (position == 1) DeleteFirst();
            else if (position == Count + 1) DeleteLast();
            else 
            {
                int x = 1;
                Node current = head;
                while (x < position - 1) 
                {
                    current = current.next;
                    x++;
                }

                current.next = current.next.next;
            }
        }
        public void DeleteLast() 
        {
            if (Count == 1)
            {
                head = null;
                Count = 0;
                return;
            }
            else if (Count == 0) return;


            Node current = head;
            while (current.next.next != head) current = current.next;

            current.next.next = null;
            current.next = head;


            Count--;
        }

        public void AddByVariant(int data)
        {
            if (head == null)
            {
                head = new Node(data.ToString());
                head.next = head;
                Count++;
                return;
            }

            if (data > 0) AddFirst(data.ToString());
            else 
            {
                Node new_node = new Node(data.ToString(), head.next);
                head.next = new_node;
            }
        }

        public void Print() 
        {
            WriteLine("\n============================== The current list ==============================");
            if (Count == 0) 
            {
                WriteLine("\n==============================================================================\n");
                return;
            }
            

            Node current = head;
            bool check = false;
            while (current != head || check == false) 
            {
                Write($"{current.data} ");
                current = current.next;
                check = true;
            }
            WriteLine("\n==============================================================================\n");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            SLList arr = null;
            Random rnd = new Random();
            try
            {
                Write("Enter the head: ");
                int x;
                x = int.Parse(ReadLine());
                arr = new SLList(x.ToString());
                for (int i = 1; i <= 2; i++) arr.AddLast(rnd.Next(-15, 15).ToString());
            }
            catch (Exception e) 
            {
                WriteLine(e.Message);
                return;
            }


            bool work = true;
            Console.Clear();
            while (work) 
            {
                Console.Clear();
                arr.Print();
                try
                {
                    Write("Enter 1, if you would like to see the list of command\nEnter 2, if you would like to finish program: ");
                    int a = int.Parse(ReadLine());
                    if (a < 0 || a > 2) throw new Exception("Invalid input");

                    if (a == 2) work = false;
                    if (a == 1) 
                    {
                        Console.Clear();

                        WriteLine("The list of command:\n");

                        WriteLine("/AddFirst - 1");
                        WriteLine("/AddLast - 2");
                        WriteLine("/AddAtPosition - 3");
                        WriteLine("/DeleteFirst - 4");
                        WriteLine("/DeleteLast - 5");
                        WriteLine("/DeleteAtPosition - 6");
                        WriteLine("/AddByVariant - 7\n");   

                        Write("Choose the command: ");
                        int command = int.Parse(ReadLine());
                        if (command < 1 || command > 7) throw new Exception();


                        int value;
                        int position;
                        switch (command) 
                        {
                            case 1:
                                Write("Enter the value: ");
                                value = int.Parse(ReadLine());

                                arr.AddFirst(value.ToString());
                                break;
                            case 2:
                                Write("Enter the value: ");
                                value = int.Parse(ReadLine());

                                arr.AddLast(value.ToString());
                                break;
                            case 3:
                                Write("Enter the value: ");
                                value = int.Parse(ReadLine());

                                Write("Enter the position: ");
                                position = int.Parse(ReadLine());
                                arr.AddToPosition(value.ToString(), position);
                                break;
                            case 4:
                                arr.DeleteFirst();
                                break;
                            case 5:
                                arr.DeleteLast();
                                break;
                            case 6:
                                Write("Enter the position: ");
                                position = int.Parse(ReadLine());
                                arr.DeleteFromPosition(position);
                                break;
                            case 7:
                                Write("Enter the value: ");
                                value = int.Parse(ReadLine());
                                arr.AddByVariant(value);
                                break;
                        }
                    }
                }
                catch 
                {
                    Console.Clear();
                }
            }
        }
    }
}
