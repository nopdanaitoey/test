using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_HarmonyX_API.Model;
using Test_HarmonyX_API.Interfaces;
using Test_HarmonyX_API.Util;

namespace Test_HarmonyX_API.Controllers
{
    [Route("fortest")]
    [ApiController]
    public class testharmonyx : Controller
    {
        private readonly ILogger<testharmonyx> _logger;
        private readonly IPromotionService _promotionService;
        private readonly IExchangeService _exchangeService;

        public testharmonyx(ILogger<testharmonyx> logger, IPromotionService promotionService, IExchangeService exchangeService)
        {
            _logger = logger;
            _promotionService = promotionService;
            _exchangeService = exchangeService;
        }

        [HttpPost("twosum")]
        public ActionResult GetTwosum([FromBody] TwoSumModelView TwoSumModel)
        {
            try
            {
                string Message = String.Empty;
                ResultTwoSum ResultReturn = new ResultTwoSum();
                List<int?> ArrayResult = new List<int?>();

                if (TwoSumModel.Nums.Count < 0 || TwoSumModel.Target == null)
                {
                    return BadRequest(new { Message = "The TwoSumModel field is required" });
                }
                else
                {
                    ArrayResult = TwoSum.ProcessTwoSum(TwoSumModel.Nums, TwoSumModel.Target);
                    if (ArrayResult.Count > 0)
                    {
                        Message = $"Nums [{string.Join(",", ArrayResult)}], Target {TwoSumModel.Target}";
                    }
                    else
                    {
                        Message = $"No two sum solution";
                    }
                }
                return Ok(new ResultTwoSum { Result = ArrayResult, Message = Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ResultCatch = new { Message = "เกิดข้อผิดพลาดจากระบบ กรุณาลองใหม่อีกครั้ง", Code = ex },
                });
            }
        }
        [HttpGet("exchange")]
        public ActionResult GetExchange(int? Price, int? Pay)
        {
            try
            {
                List<string> Meassage = new List<string>();
                List<Object> results = new List<Object>();
                ReturnResultExchange Results = new ReturnResultExchange();
                if (Price == null || Pay == null)
                {
                    return BadRequest(new { Message = "Please provide price and pay" });
                }
                else if (Price > Pay)
                {
                    return BadRequest(new { Message = "Price more than Pay" });
                }
                else if (Price == Pay)
                {
                    return Ok(new { Message = "no to change" });
                }
                else
                {
                    int? mustExchange = Pay - Price;
                    Results = _exchangeService.ProcressExchange(mustExchange);
                }
                return Ok(new ReturnResultExchange { Exchange = Results.Exchange, Message = $"{string.Join(",", Results.Message)}" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ResultCatch = new { Message = "เกิดข้อผิดพลาดจากระบบ กรุณาลองใหม่อีกครั้ง", Code = ex },
                });
            }
        }

        [HttpPost("promotion")]
        public ActionResult PostPromotion([FromBody] List<ProductInputModelView> product)
        {
            try
            {
                var ResultReturn = _promotionService.Promotions(product);
                return Ok(ResultReturn);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ResultCatch = new { Message = "เกิดข้อผิดพลาดจากระบบ กรุณาลองใหม่อีกครั้ง", Code = ex },
                });
            }
        }

    }
}
