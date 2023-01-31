using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_HarmonyX_API.Model
{
    public class ReturnExchangeModelView
    {
        public int? Banknote { get; set; }
        public int? AmountExchange { get; set; }
    }

    public class ReturnResultExchange
    {
        public string Message { get; set; }
        public List<Object> Exchange { get; set; }
    }

}