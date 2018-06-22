using System;

namespace lottery_logic
{
    class Program
    {
        static void Main(string[] args)
        {
           ticket WinningTicket = new ticket();
           WinningTicket.QuickPick();
          while (true) 
            {
                int response = 0;
                
                while (response != 1 && response != 2)
                 {
                    Console.Clear();
                    Console.WriteLine("Lottery App\n");
                    Console.WriteLine("Main Menu\n1. Buy Ticket\n2. Check Ticket");
                    Int32.TryParse(Console.ReadLine(), out response);
                   
                }
                if (response == 1)
                {
                    response = 0;
                    while (response != 1 && response != 2 && response != 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Lottery App\n");
                        Console.WriteLine("Buy Ticket Menu\n1. QuickPick\n2. Pick Five\n3. Return to Main Menu");
                        Int32.TryParse(Console.ReadLine(), out response);
                    }
                    if (response == 1)
                    {

                    }
                }
                
            }
            
        }
    }
}
