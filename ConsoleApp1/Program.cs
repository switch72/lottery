using System;

namespace lottery_logic
{
    class Program
    {
        static void Main(string[] args)
        {
            ticket WinningTicket = new ticket();
            WinningTicket.QuickPick();
        }
    }
}
