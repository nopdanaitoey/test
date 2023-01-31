using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_HarmonyX_API.Model
{
    public class TwoSumModelView
    {
        public List<int> Nums { get; set; }
        public int Target { get; set; }
    }
    public class ResultTwoSum
    {
        public string Message { get; set; }
        public List<int?> Result { get; set; }
    }
}