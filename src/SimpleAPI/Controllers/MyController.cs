using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers
{
    [ApiController]
    // [Route("{controller}/{action}/{currency}")]
    // [Route("{controller}/{action}")]
    [Route("api/mycontroller")]
    public class MyController : ControllerBase
    {
        // [HttpGet("{id:int:min(2)}")]
        // public IActionResult Get(int id)
        // {
        //     return Ok($"Yup it is {id}");
        // }

        // [HttpGet]
        [HttpGet("{currency}")]
        public IActionResult Get(string currency)
        {
            return Ok($"Yes it is {currency}");
        }
    }
}