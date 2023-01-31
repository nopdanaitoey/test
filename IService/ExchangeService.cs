using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_HarmonyX_API.Interfaces;
using Test_HarmonyX_API.Model;

namespace Test_HarmonyX_API.IService
{
    public class ExchangeService : IExchangeService
    {
        public List<int> MyExchange = new List<int> { 1, 2, 5, 10, 20, 50, 100, 500, 1000 };
        public ReturnResultExchange ProcressExchange(int? mustExchange)
        {
            List<string> Meassage = new List<string>();
            List<Object> results = new List<Object>();
            for (int i = MyExchange.Count - 1; i >= 0; i--)
            {
                ReturnExchangeModelView obj = new ReturnExchangeModelView() { Banknote = MyExchange[i], AmountExchange = mustExchange / MyExchange[i] };
                results.Add(obj);
                if (MyExchange[i] > 10 && mustExchange / MyExchange[i] > 0)
                {
                    Meassage.Add($"ทอนด้วยแบงค์ {MyExchange[i]} {mustExchange / MyExchange[i]} ใบ");
                }
                else if (MyExchange[i] <= 10 && mustExchange / MyExchange[i] > 0)
                {
                    Meassage.Add($"ทอนด้วยเหรียญ {MyExchange[i]} {mustExchange / MyExchange[i]} เหรียญ");
                }
                mustExchange = mustExchange % MyExchange[i];
            }
            return new ReturnResultExchange { Exchange = results, Message = $"{string.Join(",", Meassage)}" };
        }
    }
}