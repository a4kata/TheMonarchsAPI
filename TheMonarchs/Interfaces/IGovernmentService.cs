using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheMonarchs.Models;

namespace TheMonarchs.Interfaces
{
    public interface IGovernmentService
    {
        Task<int> GetCount();
        Task<IList<T>> GetAll<T>();
        Task<string> GetLongestRuled();
        Task<string> GetLongestRuledHouse();
        Task<string> GetMostCommonRulerName();
    }
}
