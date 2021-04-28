using API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace API.Errors
{
    public class ErrorController : BaseApiController
    {
        [Route("errors/{code}")]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponses(code));   
        }   
    }
}