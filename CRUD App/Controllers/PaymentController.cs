using CRUD_App.Interfaces;
using CRUD_App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly ILogger<PaymentController> _logger;
        public PaymentController(IPaymentService paymentService, ILogger<PaymentController> logger)
        {
            _paymentService = paymentService;
            _logger = logger;
        }

        [HttpGet("get-payment-list")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(List<PaymentDetail>))]
        [ProducesResponseType(400)]
        public IActionResult GetAll()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _paymentService.GetAll();
                    return Ok(result);
                }

                var ErrorResponse = new ErrorResponse { ErrorCode = "490", ErrorDescription = "There is an error in the System's Server-Side. Please try again.", ErrorGeneratedAt = DateTime.Now };
                return BadRequest(ErrorResponse);
            } 
            catch (Exception ex) {
                _logger.LogError(ex.Message);
                var ErrorResponse = new ErrorResponse { ErrorCode = "999", ErrorDescription = ex.Message, ErrorGeneratedAt = DateTime.Now };
                return BadRequest(ErrorResponse);
            }
        }

        [HttpGet("get-payment/{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(PaymentDetail))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetPayment([FromRoute] dynamic id)
        {
            int integerId; 

            if (!ModelState.IsValid) 
            {
                var InvalidErrorResponse = new ErrorResponse { ErrorCode = "490", ErrorDescription = "There is an error in the System's Server-Side. Please try again.", ErrorGeneratedAt = DateTime.Now };
                return BadRequest(InvalidErrorResponse);
            }

            if (int.TryParse(id, out integerId))
            {
                var result = _paymentService.GetPaymentDetail(id);
                return Ok(result);
            }

            var ErrorResponse = new ErrorResponse { ErrorCode = "491", ErrorDescription = "Input Id value should be valid type of value.", ErrorGeneratedAt = DateTime.Now };
            return BadRequest(ErrorResponse);
        }

        [HttpPost("create-payment")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(400)]
        public IActionResult CreatePayment([FromBody] PaymentDetail paymentDetail)
        {
            if (ModelState.IsValid) 
            {
                var result = _paymentService.AddPayment(paymentDetail);
                return Ok(result);
            }

            var ErrorResponse = new ErrorResponse { ErrorCode = "490", ErrorDescription = "There is an error in the System's Server-Side. Please try again.", ErrorGeneratedAt = DateTime.Now };
            return BadRequest(ErrorResponse);
        }

        [HttpPut("update-payment/{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdatePayment([FromRoute] int id, [FromBody] PaymentDetail paymentDetail)
        {
            if (!ModelState.IsValid) 
            {
                var InValidErrorResponse = new ErrorResponse { ErrorCode = "490", ErrorDescription = "There is an error in the System's Server-Side. Please try again.", ErrorGeneratedAt = DateTime.Now };
                return BadRequest(InValidErrorResponse);
            }
            if (_paymentService.PaymentExists(id))
            {
                var result = _paymentService.UpdatePayment(id, paymentDetail);
                return Ok(result);
            }
            var CustomErrorResponse = new ErrorResponse { ErrorCode = "404", ErrorDescription = "This items not exists in the System. Please check the item and come again.", ErrorGeneratedAt = DateTime.Now };
            return NotFound(CustomErrorResponse);
        }

        [HttpDelete("delete-payment/{id:int}")]
        [AllowAnonymous]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeletePayment([FromRoute] int id) 
        {
            if (!ModelState.IsValid) 
            {
                var InValidErrorResponse = new ErrorResponse { ErrorCode = "490", ErrorDescription = "There is an error in the System's Server-Side. Please try again.", ErrorGeneratedAt = DateTime.Now };
                return BadRequest(InValidErrorResponse);
            }
            if (_paymentService.PaymentExists(id)) 
            {
                var result = _paymentService.DeletePayment(id);
                return Ok(result);
            }
            var CustomErrorResponse = new ErrorResponse { ErrorCode = "404", ErrorDescription = "This items not exists in the System. Please check the item and come again.", ErrorGeneratedAt = DateTime.Now };
            return NotFound(CustomErrorResponse);
        }
    }
}
