using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Physician_BussinessLogic;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace PhysicianAvailabilityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhysicianAvailabilityController : ControllerBase
    {
        ILogic _logic;
        public PhysicianAvailabilityController(ILogic logic)
        {
            _logic = logic;
        }
        [HttpPost("AddPhysicianAvailable")]
        public ActionResult AddNewPhysician([FromBody] Physicianavailability a)
        {
            try
            {
                var tdata = _logic.AddPhysician(a);
                return Created("Added", tdata);
            }
            catch (SqlException se)
            {
                return BadRequest(se.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get_All_Physicians")]
        public ActionResult Get()
        {
            try
            {
                var t = _logic.GetAll();
                if (t.Count() > 0)
                {
                    return Ok(t);
                }
                else
                {
                    return BadRequest("No data");
                }
            }
            catch (SqlException e)
            {
                return BadRequest("Could not found");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("FindDoctorByEmailID/{EmailID}")]
        public IActionResult FindDoctorByEmailID([FromRoute] String EmailID)
        {
            try
            {
                var s = _logic.FindDoctorByEmailID(EmailID);
                if (s != null)
                {
                    return Ok(s);
                }
                else
                {
                    return NotFound("No dotor");
                }
            }

            catch (SqlException er)
            {
                return BadRequest("No data found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("DeletephysicianAvailability/{EmailID}")]
        public ActionResult Delete([FromRoute] string EmailID)
        {
            try
            {
                if (!string.IsNullOrEmpty(EmailID))
                {
                    var r = _logic.DeletePhy(EmailID);
                    if (r != null)
                        return Ok(r);
                    else
                        return BadRequest("No Data Found with this Email");

                }
                else
                {
                    return BadRequest("Please add a correct value  to be deleted");
                }
            }
            catch (SqlException er)
            {
                return BadRequest("no data found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("UpdatePhysicianavailability/{Email}")]
        public ActionResult Updatephy([FromRoute] string Email, Physicianavailability d)
        {
            try
            {
                if (!string.IsNullOrEmpty(Email))
                {
                    _logic.UpdatePhysician(Email, d);
                    return Ok(d);
                }
                else
                {
                    return BadRequest($"Please check your EmailID");
                }
            }
            catch (SqlException er)
            {
                return BadRequest("No data found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
