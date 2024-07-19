using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppRevendedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResellerController : ControllerBase
    {
       [HttpGet]
       public ActionResult Get() {
            return Ok();
       }
    }
}
