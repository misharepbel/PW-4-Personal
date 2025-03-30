using EShop.Application;
using EShop.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;
//using System.Web.Http;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private ICreditCardService _ccs;
        public CreditCardController(ICreditCardService ccs)
        {
            _ccs = ccs;
        }
        // GET api/<CreditCardController>/5
        [HttpGet()]
        public IActionResult Get(string cardNumber)
        {
            try
            {
                _ccs.ValidateCard(cardNumber);
                return Ok(new { message = _ccs.GetCardType(cardNumber)});
            }
            catch (CardNumberTooLongException ex)
            {
                return StatusCode((int)HttpStatusCode.RequestUriTooLong, new { ex.Message });
            }
            catch (CardNumberTooShortException ex)
            {
                return BadRequest(new { error = ex.Message, code = HttpStatusCode.BadRequest });
            }
            catch (CardNumberInvalidException ex)
            {
                string msg = ex.Message;
                if (msg == "The provided card number does not match any of the registered card types.")
                {
                    return StatusCode((int)HttpStatusCode.NotAcceptable, new { msg });
                }
                return BadRequest(new { error = msg, code = HttpStatusCode.BadRequest });
            }
        }


        // POST api/<CreditCardController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<CreditCardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<CreditCardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
