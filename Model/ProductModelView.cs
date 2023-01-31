using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_HarmonyX_API.Model
{
    public class MyProductModelView
    {
        public string Product { get; set; }
        public ProductModelView Details { get; set; }
    }
    public class ProductModelView
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
    public class ProductInputModelView
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
    public class PromotionDetailModelView
    {
        public string Description { get; set; }
        public decimal? Discount { get; set; }
    }
    public class ProductDetailModelView
    {
        public decimal? PriceBeforeDiscount { get; set; }
        public decimal? TotalDiscount { get; set; }
        public decimal? PriceAfterDiscount { get; set; }
        public string Message { get; set; }
        public List<PromotionDetailModelView> PromotionDetails { get; set; }
    }
}