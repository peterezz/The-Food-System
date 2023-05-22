//using ECommerce.DAL.Models.Client;
//using ECommerce.DAL.Reposatory.RepoServices;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace ECommerce.API.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class PayPalController : ControllerBase
//    {
//        private readonly PaypalClient _paypalClient;

//        public PayPalServices PayPalServices { get; }

//        public PayPalController(PayPalServices payPalServices)
//        {

//            PayPalServices = payPalServices;
//        }
  
//        [HttpPost("CreateOrder")]
//        public async Task<IActionResult> Order(CancellationToken cancellationToken)
//        {
//            try
//            {
//                // set the transaction price and currency
//                var price = "100.00";
//                var currency = "USD";

//                // "reference" is the transaction key
//                var reference = "INV001";

//                var response = await PayPalServices.CreateOrder(price, currency, reference);

//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                var error = new
//                {
//                    e.GetBaseException().Message
//                };

//                return BadRequest(error);
//            }
//        }

//        [HttpPost("CaptureOrder")]
//        public async Task<IActionResult> Capture(string orderId, CancellationToken cancellationToken)
//        {
//            try
//            {
//                var response = await PayPalServices.CaptureOrder(orderId);

//                var reference = response.purchase_units[0].reference_id;

//                // Put your logic to save the transaction here
//                // You can use the "reference" variable as a transaction key

//                return Ok(response);
//            }
//            catch (Exception e)
//            {
//                var error = new
//                {
//                    e.GetBaseException().Message
//                };

//                return BadRequest(error);
//            }
//        }

//        [HttpGet("Success")]
//        public IActionResult Success()
//        {
//            return Ok();
//        }
//    }
//}
