using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        // private IPaymentService paymentService {get;set;}

        // public ValuesController(IPaymentService paymentService)
        // {
        //     this.paymentService = paymentService;
        // }

        public string Get([FromServices] IPaymentService paymentService)
        {
            // return this.paymentService.GetMessage();
            return paymentService.GetMessage();
        }
    }
}