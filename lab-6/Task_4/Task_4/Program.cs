using System;
using static System.Console;
using System.Data;

namespace Task_26
{
    class NodeStack
    {
        public Node top;
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
        public NodeStack()
        {
            top = null;
            Count = 0;
        }
        public NodeStack(string data)
        {
            top = new Node(data);
            top.next = top;
            Count = 1;
        }
        public void Push(string data)
        {
            if (top == null)
            {
                top = new Node(data);
                top.next = top;
                Count++;
                return;
            }
            Node current = top;
            Node new_top = new Node(data, top);

            new_top.next = current;
            top = new_top;
            Count++;
        }
        public string Pop()
        {
            if (top == null) return null;
            else if (Count == 1)
            {
                string x = top.data;
                top = null;
                Count--;
                return x;
            }
            else 
            {
                Node current = top;
                string x = current.data;
                Node new_top = current.next;
                top = new_top;
                Count--;
                

                return x;
            }
        }
        public string Peek()
        {
            if (top == null) return null;

            return top.data;
        }
        public int Size()
        {
            return Count;
        }
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Print()
        {
            WriteLine("\n============================== The current stack ==============================");
            if (Count == 0)
            {
                WriteLine("\n==============================================================================\n");
                return;
            }

            Node current = top;
            int count_right = Count;
            while (count_right > 0) 
            {
                Write($"{current.data} ");
                current = current.next;
                count_right--;
            }
            WriteLine("\n==============================================================================\n");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Write("Please, enter the expression in infix form or Enter 's', for stop program: ");
                    string a = ReadLine();

                    if (a == "s") break;
                    a = a.Replace(" ", "");
                    if (!chechMathCorrect(a)) throw new Exception("\nThe entered string is not in infix form, please try again");
                    else
                    {
                        a = a.Replace(" ", "");

                        string result = "";
                        NodeStack stack = new NodeStack();
                        for (int i = 0; i < a.Length; i++)
                        {
                            if (a[i] == ')')
                            {
                                while (stack.Peek() != "(")
                                {
                                    string c = stack.Pop();
                                    result += c;
                                }
                                stack.Pop();
                            }

                            else if (checkSpecSymbol(a[i]))
                            {
                                if (Prior(a[i].ToString()) <= Prior(stack.Peek()) && a[i] != '(')
                                {
                                    while (stack.Peek() != "(" && stack.IsEmpty() == false)
                                    {
                                        string c = stack.Pop();
                                        result += c;
                                    }
                                    stack.Push(a[i].ToString());
                                }
                                else stack.Push(a[i].ToString());
                            }

                            else result += a[i].ToString();
                        }

                        while (!stack.IsEmpty()) result+=stack.Pop();


                        Write("\nThe result is: ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
                        WriteLine(" " + result + " ");
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }

                Write("\nPress to continue...");
                ReadKey();
                Console.Clear();
            }
        }

        static bool chechMathCorrect(string a)
        {
            try
            {
                string x = "";
                Random random = new Random();  
                for (int i = 0; i < a.Length; i++)
                {
                    if (i >= 1 && i <= a.Length - 2)
                    {
                        if (a[i] >= 'a' && a[i] <= 'z')
                        {
                            if (IsLetters(a[i - 1]) || IsLetters(a[i + 1])) throw new Exception();
                            else x += random.Next(1, 10).ToString();
                        }
                        else x += a[i].ToString();
                    }
                    else if (i == 0)
                    {
                        if (a[i] >= 'a' && a[i] <= 'z')
                        {
                            if (IsLetters(a[i + 1])) throw new Exception();
                            else x += random.Next(1, 10).ToString();
                        }
                        else x += a[i].ToString();
                    }
                    else if (i == a.Length - 1)
                    {
                        if (a[i] >= 'a' && a[i] <= 'z')
                        {
                            if (IsLetters(a[i - 1])) throw new Exception();
                            else x += random.Next(1, 10).ToString();
                        }
                        else x += a[i].ToString();
                    }
                    else 
                    {
                        x += a[i].ToString();
                    }
                }

                string value = new DataTable().Compute(x, null).ToString();
                if (value.Length == 0) throw new Exception();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static int Prior(string a)
        {

            switch (a)
            {
                case "*":
                case "/":
                    return 3;

                case "–":
                case "+":
                    return 2;

                case "(":
                    return 1;
            }
            return 0;
        }
        static bool checkSpecSymbol(char a)
        {
            if (a == '/' || a == '*' || a == '-' || a == '+' || a == '(') return true;
            else return false;
        }
        static bool IsLetters(char a) 
        {
            if (a >= 'a' && a <= 'z') return true;
            else if (a >= '0' && a <= '9') return true;
            else return false;
        }
    }
}
