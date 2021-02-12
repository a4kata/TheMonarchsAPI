using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMonarchs.Models;

namespace TheMonarchsAPI.Utilities
{
    public static class Utility
    {
        public static void CalcPeriod(Monarch m)
        {

            if (m.yrs.Contains("-"))
            {
                string[] yearsAsTexts = m.yrs
            .Split('-')
            .Select(yearText => yearText.Trim())
            .ToArray();
                string startYearText = yearsAsTexts[0];
                string endYearText = "0";
                if (string.IsNullOrEmpty(yearsAsTexts[1]))
                    endYearText = DateTime.Now.Year.ToString();
                else
                    endYearText = yearsAsTexts[1];

                m.period = Convert.ToInt32(endYearText) - Convert.ToInt32(startYearText);
                m.period = m.period < 0 ? m.period * -1 : m.period;
            }
            else
                m.period = 1;
        }
    }
}
