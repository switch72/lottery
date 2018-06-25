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
           WinningTicket.QuickPick();
           MainMenu();
            
            foreach (ticket displayticket in Ticketlist)
            {
                Console.WriteLine("Ticket Number:{0}", displayticket.ReadTicketNumber());
                Console.Write("Balls: ");
                foreach (int num in displayticket.ReadTicket())
                {
                    Console.Write("{0} ", num);
                }

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
            string userballs;
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
                newticket.QuickPick();
                Ticketlist.Add(newticket);
            }
            if (response == 2)
            {
                ticket newticket = new ticket();
                Console.Write("Enter ball choices seperated by spaces. \nFirst five balls must be unique and be from 1 through 69. \nLast ball is powerball and must be from 1 through 26.\nBall List:");
                userballs = Console.ReadLine();
                //List<int> ballintlist = userballs.Split(' ').ToList().Select(int.Parse).ToList();
                List<string> ballstringlist = userballs.Split(' ').ToList();
                List<int> ballintlist = new List<int>();
                int ballint;
                foreach (string ball in ballstringlist)
                {
                    Int32.TryParse(ball, out ballint);
                    ballintlist.Add(ballint);
                }
                try { newticket.PickSix(ballintlist);
                    Ticketlist.Add(newticket);
                }
                catch (ArgumentException error) { Console.WriteLine("{0}: Press any key to try again...", error.Message); Console.ReadLine(); BuyMenu(); }
                
            }

        }

        static void CheckMenu()
        {

        }

    }
}
