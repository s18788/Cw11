using Microsoft.AspNetCore.Mvc;

namespace Cw11.Controllers
{
    [ApiController]
    public class DoctorsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddDoctor()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult ModifyDoctor()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteDoctor()
        {
            return Ok();
        }



    }
}
