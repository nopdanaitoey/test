using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_HarmonyX_API.Model;

namespace Test_HarmonyX_API.Util
{
    public static class TwoSum
    {
        public static List<int?> ProcessTwoSum(List<int> Nums, int Target)
        {
            List<int?> Resultprocess = new List<int?>();
            for (int i = 0; i < Nums.Count; i++)
            {
                for (int j = i + 1; j < Nums.Count; j++)
                {
                    if (Nums[i] + Nums[j] == Target)
                    {
                        Resultprocess.Add(i);
                        Resultprocess.Add(j);
                    }
                }
            }
            return Resultprocess.ToList();
        }
    }
}