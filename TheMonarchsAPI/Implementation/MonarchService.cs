using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TheMonarchs.Interfaces;
using TheMonarchs.Models;
using TheMonarchsAPI.Utilities;

namespace TheMonarchs.Implementation
{
    public class MonarchService : IGovernmentService
    {
        public List<Monarch> AllMonarches { get; }

        public MonarchService()
        {
            var json = File.ReadAllText($"Data/Monarchs.json");
            AllMonarches = JsonSerializer.Deserialize<List<Monarch>>(json);
            AllMonarches.ForEach(m => Utility.CalcPeriod(m));
        }

        public Task<IList<T>> GetAll<T>()
        {
            return Task.FromResult((IList<T>)(IList<T>)AllMonarches);
        }

        public Task<string> GetLongestRuled()
        {
            int period = AllMonarches.OrderByDescending(m => m.period).FirstOrDefault().period;
            string nm = AllMonarches.OrderByDescending(m => m.period).FirstOrDefault().nm;
            return Task.FromResult($"Monarch {nm} ruled for {period} years");
        }

        public Task<string> GetLongestRuledHouse()
        {
            return GroupByHouses();
        }

        public Task<string> GetMostCommonRulerName()
        {
            string name = AllMonarches.GroupBy(m => m.nm.Split()[0]).OrderByDescending(m => m.Count()).ToList().FirstOrDefault().Key;
            return Task.FromResult($"Most common monarch name is {name}");
        }

        public Task<string> GetMonarchsCount()
        {
            return Task.FromResult($"The total number of monarchs is {AllMonarches.Count()}");
        }

        public Task<int> GetCount()
        {
            return Task.FromResult(AllMonarches.Count());
        }

        private Task<string> GroupByHouses()
        {
            Dictionary<string, int> houses = new Dictionary<string, int>();
            foreach (var house in AllMonarches.GroupBy(m => m.hse).ToList())
            {
                int totalYears = 0;
                foreach (var m in house)
                {
                    totalYears += m.period;
                }
                houses.Add(house.Key, totalYears);
            }
            var longest = houses.OrderByDescending(h => h.Value).FirstOrDefault();
            return Task.FromResult($"{longest.Key} ruled for {longest.Value} years");
        }
    }
}
