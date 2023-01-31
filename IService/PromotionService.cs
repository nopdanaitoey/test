using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_HarmonyX_API.Interfaces;
using Test_HarmonyX_API.Model;

namespace Test_HarmonyX_API.Iservice
{
    public class PromotionService : IPromotionService
    {
        Dictionary<string, int> MyProduct = new Dictionary<string, int>()
            {
                {"A", 99},
                {"B", 199},
                {"C", 3990}
            };
        public decimal? PromotionA = 200;
        public List<string> PromotionB = new List<string>() { "A", "B" };

        public ProductDetailModelView Promotions(List<ProductInputModelView> product)
        {
            decimal TotalPrice = 0;
            ProductDetailModelView Results = new ProductDetailModelView();
            Results.PromotionDetails = new List<PromotionDetailModelView>();
            decimal aCount = 0, bCount = 0; //นับจำนวน A, B
            decimal? TotalDiscount = 0;
            foreach (var item in product)
            {
                if (MyProduct.ContainsKey(item.Name)) // Check Product ว่ามีอยู่ในListไหม
                {

                    TotalPrice += MyProduct[item.Name] * item.Amount;
                }

                if (item.Name == "A")
                {
                    aCount = item.Amount;
                }
                else if (item.Name == "B")
                {
                    bCount = item.Amount;
                }
            }
            bool IsPromotionA = TotalPrice >= PromotionA; // Check เงื่อนไขโปรโมชั่น A
            if (IsPromotionA)
            {
                Results.PromotionDetails.Add(CalPromotionA(TotalPrice));
            }
            bool IsPromotionB = aCount > 0 && bCount > 0; // Check เงื่อนไขโปรโมชั่น B
            if (IsPromotionB)
            {
                Results.PromotionDetails.Add(CalPromotionB(aCount, bCount));
            }

            foreach (var discount in Results.PromotionDetails)
            {
                TotalDiscount += discount.Discount;
            }
            Results.PriceBeforeDiscount = TotalPrice;
            Results.TotalDiscount = TotalDiscount;
            Results.PriceAfterDiscount = TotalPrice - TotalDiscount;
            Results.Message = $"ราคาที่ต้องจ่าย {Results.PriceAfterDiscount} บาท";


            return Results;
        }

        public PromotionDetailModelView CalPromotionA(decimal TotalPrice)
        {
            decimal IsDiscountPromotionA = 10; //ลด 10 เปอเซนต์
            decimal DiscountPromotionA = (TotalPrice * IsDiscountPromotionA) / 100;
            var PromotionADetails = $"ซื้อครบ 200 บาท ลด 10%, ลูกค้าซื้อสินค้าทั้งสิ้น {TotalPrice} บาท ลดไปทั้งสิ้น {DiscountPromotionA} บาท";
            PromotionDetailModelView ResultPromotionA = new PromotionDetailModelView { Description = PromotionADetails, Discount = DiscountPromotionA };
            return ResultPromotionA;
        }

        public PromotionDetailModelView CalPromotionB(decimal aCount, decimal bCount)
        {
            decimal DiscountPromotionB = Math.Min(aCount, bCount) * 50; //หาคู่ของสิ้นค้า A, B
            var PromotionADetails = $"ซื้อ A + B ลด 50 บาท, ซื้อ A {aCount} ชื้น ซื้อ B {bCount} ชิ้น, ซื้อไปทั้งหมด {Math.Min(aCount, bCount)} คู่ ลดทั้งหมด {DiscountPromotionB} บาท";
            return new PromotionDetailModelView { Description = PromotionADetails, Discount = DiscountPromotionB };
        }
    }
}