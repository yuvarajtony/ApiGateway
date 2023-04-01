using Allergy_Business_Logic;
using EntityApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Capstone_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : Controller
    {
        ILogic logic;
        public AllergyController(ILogic logic) => this.logic = logic;

        [HttpGet("Fetch/{VisitId}")]
        public IActionResult Get([FromRoute] int VisitId)
        {
            try
            {
                var allergy = logic.Get(VisitId);
                return Ok(allergy);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Add")]
        public IActionResult Add([FromBody] Models.Allergy allergy)
        {
            var ne = logic.AddDetails(allergy);
            return Created("Add", ne);
        }
    }
}
