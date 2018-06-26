using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lottery_logic
{
    class ticket
    {
        private static readonly int maxballvalue = 69;
        private static readonly int minballvalue = 1;
        private static readonly int maxpowerballvalue = 26;
        private static readonly int minpowerballvalue = 1;
        private static int totaltickets = 0;
        private bool powerplay;
        private long ticketdate;
        private int ticketnumber;
        private List<int> whiteballs = new List<int>(Enumerable.Range(minballvalue, maxballvalue));
        private List<int> ballschosen = new List<int>();

        public ticket()
        {
            totaltickets += 1;
            ticketnumber = totaltickets;
        }


        public void QuickPick(bool powerplayselection)
        {
            if (ballschosen.Count == 0)
            {
                ticketdate = DateTime.Now.Ticks;
                Random ballpick = new Random();
                for (int ball = 0; ball < 5; ball++)
                {
                    int randomball = ballpick.Next(whiteballs.Count);
                    ballschosen.Add(whiteballs[randomball]);
                    whiteballs.RemoveAt(randomball);
                }
                ballschosen.Add(ballpick.Next(minpowerballvalue, maxpowerballvalue));
                powerplay = powerplayselection;
            }
            else
            {
                throw new System.ArgumentException("Ticket already created, cannot pick new numbers.");
            }
        }

        public void PickSix(List<int> picklist, bool powerplayselection)
        {
            if (ballschosen.Count == 0)
            {
                if (picklist.Count == 6)
                {
                   if (ValidateBallList(picklist))
                   {
                        ballschosen.AddRange(picklist);
                        ticketdate = DateTime.Now.Ticks;
                        powerplay = powerplayselection;
                    }
                   else
                   {
                    throw new System.ArgumentException("Invalid Ball Value");
                   }                                           
                    
                
                }else
                {
                    throw new System.ArgumentException("Invalid number of balls picked");
                }
            }
            else
            {
                throw new System.ArgumentException("Ticket already created, cannot pick new numbers.");
            }

        }

        public bool PowerPlay()
        {
            return powerplay;
        }

        public int TicketNumber()
        {
            return ticketnumber;
        }

        public long TicketDate()
        {
            return ticketdate;
        }

        public List<int> ReadNumbers()
        {
            return ballschosen;
        }

        private bool ValidateBallList(List<int> checklist)
        {
            List<int> validlist = new List<int>();
            for (int ball = 0; ball < 5; ball++)
            {
                if (checklist[ball] >= minballvalue && checklist[ball] <= maxballvalue && !validlist.Contains(checklist[ball])){
                    validlist.Add(checklist[ball]);
                }else
                {
                    return false;
                }
            }

            return (checklist[5] >= minpowerballvalue && checklist[5] <= maxpowerballvalue);
              
        }

    }
}
