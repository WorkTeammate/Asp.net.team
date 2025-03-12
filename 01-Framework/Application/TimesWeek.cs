using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Framework.Application
{
    public class TimesWeek
    {
        public string Saturday { get; private set; }
        public string Sunday { get; private set; }
        public string Monday { get; private set; }
        public string Tuesday { get; private set; }
        public string Wednesday { get; private set; }
        public string Thursday { get; private set; }
        public string Friday { get; private set; }
        protected TimesWeek()
        {
        }

        public TimesWeek(string saturday, string sunday, string monday, string tuesday, string wednesday, string thursday, string friday)
        {
            Saturday = saturday;
            Sunday = sunday;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
        }
    }
}
