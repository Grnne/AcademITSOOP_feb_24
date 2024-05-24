using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TestingViews
{
    internal class Class1
    {
        public int Timer { get; set; }

        public Class1()
        {



            System.Timers.Timer tmrTimersTimer = new System.Timers.Timer();
            tmrTimersTimer.Interval = 1000;
            tmrTimersTimer.Elapsed += Timer_tick;

            

        }

        public void Timer_tick(object sender, EventArgs e)
        {
            Console.WriteLine("2");

        }

    }

}
