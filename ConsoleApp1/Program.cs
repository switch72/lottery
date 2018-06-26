using System;
using System.Collections.Generic;
using System.Linq;

namespace lottery_logic
{
    class Program
    {
        static ticket WinningTicket = new ticket();
        static List<ticket> Ticketlist = new List<ticket>(); 

        static void Main(string[] args)
        {
           WinningTicket.QuickPick(false);
           MainMenu();
            
            foreach (ticket displayticket in Ticketlist)
            {
                

                Console.WriteLine("");
            }

        }

        static void MainMenu()
        {
            while (true)
            {
                int response = 0;

                while (response != 1 && response != 2 && response != 3)
                {
                    Console.Clear();
                    Console.WriteLine("Lottery App\n");
                    Console.WriteLine("Main Menu\n1. Buy Ticket\n2. Check Ticket\n3. Exit");
                    Int32.TryParse(Console.ReadLine(), out response);

                }
                if (response == 1)
                {
                    BuyMenu();
                }
                if (response == 2)
                {
                    CheckMenu();
                }
                if (response == 3 ) break;
            }
        }

        static void BuyMenu()
        {
            int response = 0;
            bool powerplay;
            while (response != 1 && response != 2 && response != 3)
            {
                Console.Clear();
                Console.WriteLine("Lottery App\n");
                Console.WriteLine("Buy Ticket Menu\n1. QuickPick\n2. Pick six\n3. Return to Main Menu");
                Int32.TryParse(Console.ReadLine(), out response);
            }
            if (response == 1)
            {
                ticket newticket = new ticket();
                Console.WriteLine("Would you like to add powerplay?\n1. Yes\n2. No");
                powerplay = Console.ReadLine().Equals("1");
                newticket.QuickPick(powerplay);
                Ticketlist.Add(newticket);
                PrintTicket(newticket);
                Console.WriteLine("Presse any key to continue...");
                Console.ReadLine();
            }
            if (response == 2)
            {
                ticket newticket = new ticket();
                Console.Write("Enter ball choices seperated by spaces. \nFirst five balls must be unique and be from 1 through 69. \nLast ball is powerball and must be from 1 through 26.\nBall List:");
                string userballs = Console.ReadLine();
                List<string> ballstringlist = userballs.Split(' ').ToList();
                List<int> ballintlist = new List<int>();
                int ballint;
                Console.WriteLine("Would you like to add powerplay?\n1. Yes\n2. No");
                powerplay = Console.ReadLine().Equals("1");
                foreach (string ball in ballstringlist)
                {
                    Int32.TryParse(ball, out ballint);
                    ballintlist.Add(ballint);
                }
                try { newticket.PickSix(ballintlist,powerplay);
                    Ticketlist.Add(newticket);
                }
                catch (ArgumentException error) { Console.WriteLine("{0}: Press any key to try again...", error.Message); Console.ReadLine(); BuyMenu(); }
                PrintTicket(newticket);
                Console.WriteLine("Presse any key to continue...");
                Console.ReadLine();
            }
             
        }

        static void PrintTicket(ticket displayticket)
        {
            DateTime ticketdate = new DateTime(displayticket.TicketDate());
            List<int> balllist = displayticket.ReadNumbers();
            Console.WriteLine("Ticket Number: {0}", displayticket.TicketNumber().ToString("D6"));
            Console.WriteLine("Powerplay: {0}", displayticket.PowerPlay());
            Console.WriteLine("Date: {0}", ticketdate.ToString());
            Console.WriteLine("Balls: {0}-{1}-{2}-{3}-{4} {5}",balllist[0], balllist[1], balllist[2], balllist[3], balllist[4], balllist[5]);
            
        }

        static void CheckMenu()
        {   
            ticket checkticket;
            int searchnumber;
            int whitematches;
            int payout;
            bool powerballmatch;
            Console.Write("Enter ticket number to check:");
            if (Int32.TryParse(Console.ReadLine(), out searchnumber))
            {
                Console.WriteLine("Searching for ticket {0}", searchnumber);
                checkticket = Ticketlist.Find(x => x.TicketNumber() == searchnumber);
                if (checkticket != null)
                {
                    PrintTicket(checkticket);
                    Console.WriteLine("");
                    PrintTicket(WinningTicket);
                    whitematches = Enumerable.Intersect(checkticket.ReadNumbers().GetRange(0, 4), WinningTicket.ReadNumbers().GetRange(0, 4)).Count();
                    //Above line takes the intersection of the white balls for the winning ticket and the ticket we are checking, then counts the size of the intersection.
                    powerballmatch = (checkticket.ReadNumbers()[5] == WinningTicket.ReadNumbers()[5]);
                    
                    if (powerballmatch)
                    {
                        switch (whitematches)
                        {
                            case 0:
                                payout = 4;
                                break;
                            case 1:
                                payout = 4;
                                break;
                            case 2:
                                payout = 7;
                                break;
                            case 3:
                                payout = 100;
                                break;
                            case 4:
                                payout = 50000;
                                break;
                            case 5:
                                payout = -1;
                                break;
                            default:
                                payout = 0;
                                break;

                        }
                    }
                    else
                    {
                        switch (whitematches)
                        {
                            case 3:
                                payout = 7;
                                break;
                            case 4:
                                payout = 100;
                                break;
                            case 5:
                                payout = 1000000;
                                break;
                            default:
                                payout = 0;
                                break;
                        }
                    }
                    Console.WriteLine("Whiteball Matches: {0}\nPowerball Match: {1}\nPayout: " + payout, whitematches, powerballmatch);
                }
            }
            else
            {
                Console.WriteLine("Ticket Not Found.");
            }
            
            Console.WriteLine("Presse any key to continue...");
            Console.ReadLine();
        }

    }
}
