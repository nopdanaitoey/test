using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_HarmonyX_API.Model;

namespace Test_HarmonyX_API.Interfaces
{
    public interface IPromotionService
    {
        public ProductDetailModelView Promotions(List<ProductInputModelView> product);
    }
}