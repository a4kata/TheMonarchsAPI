using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheMonarchs.Models
{
    public class Monarch
    {
  
        public int id { get; set; }
        public string nm { get; set; }
        public string cty { get; set; }
        public string hse { get; set; }
        public string yrs { get; set; }
        public int period { get; set; }

        public void CalcPeriod()
        {
            try
            {
                if (yrs.Contains("-"))
                {
                    period = Convert.ToInt32(yrs.Split('-')[0]) - Convert.ToInt32(yrs.Split('-')[1]);
                    period = period < 0 ? period * -1 : period;
                }
                else
                    period = 1;
            }
            catch { }
        }
    }

}
