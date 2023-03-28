using Doctor_Business_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailblityController : ControllerBase
    {
        private readonly ILogic _logic;
        public DoctorAvailblityController(ILogic logic)
        {
            _logic = logic;
        }

        [HttpGet("particular/{email}")]
        public ActionResult GetAva([FromRoute] string email)
        {
            var users = _logic.GetDoctrAv(email);
            return Ok(users);
        }
        [HttpPost("Add")]
        public ActionResult Post([FromBody] doctor_availability user)
        {
            var users = _logic.ADD(user);
            return Ok(users);
        }

        [HttpPut("Update/{email}")]
        public ActionResult Put([FromRoute] string email, [FromBody] doctor_availability u)
        {
            var users = _logic.UpdateDoctorAv(u, email);
            return Ok(users);
        }

        [HttpGet("getdocbyStatus/{status}")]
        public ActionResult getdocbystat([FromRoute] bool status)
        {
            var users = _logic.getDocByStatus(status);
            return Ok(users);
        }
    }
}
