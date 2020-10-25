using Microsoft.AspNetCore.Mvc;

namespace SimpleAPI.Controllers
{
    [ApiController]
    [Route("api/mycontroller")]
    public class MyController : ControllerBase
    {
        [HttpGet("{id:int:min(2)}")]
        public IActionResult Get(int id)
        {
            return Ok($"Yup it is {id}");
        }
    }
}