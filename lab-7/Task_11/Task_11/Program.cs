using System;
using static System.Console;
using System.Collections.Generic;

namespace Task_11
{
    public class Program
    {
        static public List<string> CinemaHallsNames = new List<string> { "Hall_1", "Hall_2", "Hall_3", "Hall_4" };
        static public List<int> CinemaHallsSeats = new List<int> { 20, 50, 100, 30 };
         
        static void Main()
        {
            MainHashtable table = new MainHashtable();
            AdditionalHashtable addTable = new AdditionalHashtable();

            bool work = true;
            while (work)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;

                WriteLine("The list of command:\n");

                WriteLine("///Add new ticket - 1");
                WriteLine("///Remove TicketID - 2");
                WriteLine("///Find TicketID - 3");
                WriteLine("///Control example - 4");
                WriteLine("///Display content - 5");
                WriteLine("///Exit - 6");

                Console.ForegroundColor = ConsoleColor.White;
                string command = ReadLine();
                if (command.Length != 1 || (command[0] < '1' || command[0] > '6'))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine("Unknown command, please try again, enter any character to continue...");
                    Console.ForegroundColor = ConsoleColor.White;
                    ReadKey();
                    continue;
                }

                if (command[0] == '1')
                {
                    Random rnd = new Random();
                    int id = rnd.Next(221000, 999999);

                    WriteLine("Choose the Cinema Hall from the list: ");
                    for (int i = 0; i < CinemaHallsNames.Count; i++)
                    {
                        WriteLine("//" + CinemaHallsNames[i]);
                    }
                    string cinemaHall = ReadLine();
                    if (!ValidateCommand(cinemaHall, "cinemaHall"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        WriteLine("Such Cinema Hall doesn't exist");
                        Console.ForegroundColor = ConsoleColor.White;
                        ContinueUse();
                        continue;
                    }

                    Write("Enter the Movie Title: ");
                    string movieTitle = ReadLine();
                    if (!ValidateCommand(movieTitle, "movieTitle"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        WriteLine("Incorrect input");
                        Console.ForegroundColor = ConsoleColor.White;
                        ContinueUse();
                        continue;
                    }

                    Write("Enter the date, in format XX.XX.XXXX: ");
                    string InputDate = ReadLine();
                    if (!ValidateCommand(InputDate, "InputDate"))
                    { 
                        ContinueUse(); 
                        continue;
                    }
                    string[] args = InputDate.Split('.');
                    int day = int.Parse(args[0]);
                    int month = int.Parse(args[1]);
                    int year = int.Parse(args[2]);

                    Write("Enter the seat: ");
                    string Seat = ReadLine();
                    if (!ValidateCommandSeat(Seat, cinemaHall, movieTitle)) 
                    {
                        ContinueUse();
                        continue;
                    }
                    int seat = int.Parse(Seat);

                    Date date = new Date(year, month, day);

                    KeyMainTable key = new KeyMainTable(id.ToString());
                    ValueMainTable value = new ValueMainTable(movieTitle, cinemaHall, date, seat);
                    EntryMainTable entry = new EntryMainTable(key, value);

                    KeyAdditionalTable keyAdd = new KeyAdditionalTable(cinemaHall, movieTitle);
                    Ticket ticket = new Ticket(date, seat);
                    string mistake = IsSeatAvailable(keyAdd, ticket);

                    if (mistake.Length != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        WriteLine(mistake);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else 
                    {
                        table.InsertEntry(entry);
                        addTable.InsertEntry(keyAdd, ticket);
                    }

                    ContinueUse();
                }
                if (command[0] == '2') 
                {
                    Write("Enter Ticket ID: ");
                    string TicketID = ReadLine();
                    if (!ValidateCommand(TicketID, "Remove")) 
                    {
                        ContinueUse();
                        continue;
                    }

                    int ID = int.Parse(TicketID);
                    KeyMainTable key = new KeyMainTable(ID.ToString());

                    ValueMainTable value = table.GetInfo(key);
                    if (value != default)
                    {
                        Ticket ticket = new Ticket(value.date, value.seat);
                        KeyAdditionalTable keyAdd = new KeyAdditionalTable(value.cinemaHall, value.movieTitle);
                        addTable.RemoveEntry(keyAdd, ticket);
                    }

                    table.RemoveEntry(key);

                    ContinueUse();
                }
                if (command[0] == '3') 
                {
                    Write("Enter Ticket ID: ");
                    string TicketID = ReadLine();
                    if (!ValidateCommand(TicketID, "Find"))
                    {
                        ContinueUse();
                        continue;
                    }

                    int ID = int.Parse(TicketID);
                    KeyMainTable key = new KeyMainTable(ID.ToString());

                    table.ShowFindEntry(key);
                    ContinueUse();
                }
                if (command[0] == '4') 
                {
                    string cinemaHall = "Hall_1";
                    string movieTitle = "SpiderMan";
                    int year = 2020;
                    int month = 1;
                    int day = 1;
                    int seat = 5;
                    for (int i = 2; i <= 11; i++) 
                    {
                        Random rnd = new Random();
                        int id = rnd.Next(221000, 999999);

                        Date date = new Date(year, month, day);
                        KeyMainTable key = new KeyMainTable(id.ToString());
                        ValueMainTable value = new ValueMainTable(movieTitle, cinemaHall, date, seat);
                        EntryMainTable entry = new EntryMainTable(key, value);

                        KeyAdditionalTable keyAdd = new KeyAdditionalTable(cinemaHall, movieTitle);
                        Ticket ticket = new Ticket(date, seat);

                        string mistake = IsSeatAvailable(keyAdd, ticket);

                        if (mistake.Length != 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteLine(mistake);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            table.InsertEntry(entry);
                            addTable.InsertEntry(keyAdd, ticket);
                        }

                        ContinueUse();

                        seat += 1;
                    }
                }
                if (command[0] == '5') 
                {
                    table.ShowData();
                    ContinueUse();
                }
                if (command[0] == '6')
                {
                    work = false;
                    ContinueUse();
                }
            }

            string IsSeatAvailable(KeyAdditionalTable key, Ticket ticket)
            {
                string mistake = "";

                List<Ticket> arr = addTable.GetAllTicketsForDate(key, ticket.date);
                int index = CinemaHallsSeats.IndexOf(CinemaHallsSeats[CinemaHallsNames.IndexOf(key.cinemaHall.ToString())]);
                try
                {
                    if (arr.Count >= CinemaHallsSeats[index] / 2)
                        mistake = "This Hall is already half full, please select a new date!";
                    else
                    {
                        int currentSeat = ticket.seat;
                        foreach (Ticket t in arr)
                        {
                            if (t.seat == currentSeat)
                            {
                                mistake = "This place is already taken, please choose another";
                                break;
                            }
                            else if (t.seat == (currentSeat - 1) || t.seat == (currentSeat + 1))
                            {
                                mistake = "Due to the epidemic, you cannot take a seat next to another person, please choose another";
                                break;
                            }
                        }
                    }
                }
                catch (Exception) 
                {
                    
                }  
                
                return mistake;
            }
        }

        static private bool ValidateCommand(string command, string type)
        {
            bool check = true;
            if (type == "cinemaHall")
            {
                if (!CinemaHallsNames.Contains(command))
                    check = false;
            }
            else if (type == "movieTitle")
            {
                if (command.Length == 0)
                    check = false;
                else 
                {
                    string s = command.ToLower();
                    foreach (char a in s)
                    {
                        if (a < 'a' || a > 'z')
                        {
                            check = false;
                            break;
                        }
                    }
                }
                
            }
            else if (type == "InputDate")
            {
                string[] args = command.Split('.');
                try
                {
                    int day = int.Parse(args[0]);
                    int month = int.Parse(args[1]);
                    int year = int.Parse(args[2]);

                    if (year < 2010 || year > 2030)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        WriteLine($"Year must be 2010-2030, but now: {year}");
                        Console.ForegroundColor = ConsoleColor.White;
                        check = false;
                    }
                    else if (month < 0 || month > 12)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        WriteLine($"Month must be 1-12, but now: {month}");
                        Console.ForegroundColor = ConsoleColor.White;
                        check = false;
                    }
                    else
                    {
                        int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                        if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
                            daysInMonth[1]++;

                        if (daysInMonth[month - 1] < day || day < 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteLine($"In {month} month must be 01-{daysInMonth[month - 1]} days, but now: {day}");
                            Console.ForegroundColor = ConsoleColor.White;
                            check = false;
                        }
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Year, Day and Month must be integer");
                    Console.ForegroundColor = ConsoleColor.White;
                    check = false;
                }
            }
            else if (type == "Remove" || type == "Find") 
            {
                try
                {
                    int ID = int.Parse(command);
                }
                catch (Exception) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Ticket ID must be integer");
                    Console.ForegroundColor = ConsoleColor.White;
                    check = false;
                }
            }
            
            return check;
        }
        static private bool ValidateCommandSeat(string Seat, string cinemaHall, string movieTitle) 
        {
            bool check = true;
            try 
            {
                int seat = int.Parse(Seat);
                int IndexCinemaHall = CinemaHallsNames.IndexOf(cinemaHall);

                if (seat < 0 || seat > CinemaHallsSeats[IndexCinemaHall]) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteLine($"Seat must be 1-{ CinemaHallsSeats[IndexCinemaHall]}, but now {seat}");
                    Console.ForegroundColor = ConsoleColor.White;
                    check = false;
                }

                
            }
            catch (Exception) 
            {
                check = false;
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine($"Seat must be integer");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return check;
        }
        static private void ContinueUse() 
        {
            WriteLine("Enter any character to continue...");
            ReadKey();
        }

    }
}
