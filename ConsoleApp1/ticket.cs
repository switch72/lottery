using System;
using System.Collections.Generic;
using System.Text;

namespace lottery_logic
{
    class ticket
    {
        static readonly int maxballvalue = 69;
        static readonly int minballvalue = 1;
        public void QuickPick()
        {
            if (balls.Count == 0)
            {
                Random ballpick = new Random();
                for (int ball = 0; ball < 5; ball++)
                {
                    balls.Add(ballpick.Next(minballvalue, maxballvalue));
                }
            }
            else
            {
                throw new System.ArgumentException("Ticket already created, cannot pick new numbers.");
            }
        }

        public void PickFive(int ball1, int ball2, int ball3, int ball4, int ball5)
        {
            //Here I looked into using params to get a variable number of paramters
            //as this would allow me to interate over the balls rather than write 
            //code for each one, but then I have to verify each param is an int as 
            //well, and verify that I've only been passed 5 integers.
            if (balls.Count == 0)
            {

                if (Validateball(ball1))
                {
                    balls.Add(ball1);
                }
                else
                {
                    throw new System.ArgumentException("Ball value outside acceptable range.");
                }
                if (Validateball(ball2))
                {
                    balls.Add(ball2);
                }
                else
                {
                    throw new System.ArgumentException("Ball value outside acceptable range.");
                }
                if (Validateball(ball3))
                {
                    balls.Add(ball3);
                }
                else
                {
                    throw new System.ArgumentException("Ball value outside acceptable range.");
                }
                if (Validateball(ball4))
                {
                    balls.Add(ball4);
                }
                else
                {
                    throw new System.ArgumentException("Ball value outside acceptable range.");
                }
                if (Validateball(ball5))
                {
                    balls.Add(ball5);
                }
                else
                {
                    throw new System.ArgumentException("Ball value outside acceptable range.");
                }

            }
            else
            {
                throw new System.ArgumentException("Ticket already created, cannot pick new numbers.");
            }

        }

        List<int> balls = new List<int>();

        private bool Validateball(int checkball)
        {
            if (checkball >= minballvalue && checkball <= maxballvalue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
