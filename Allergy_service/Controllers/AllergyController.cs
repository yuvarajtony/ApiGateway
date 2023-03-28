using Allergy_Business_Logic;
using EntityApi.Entities;
using Microsoft.AspNetCore.Mvc;


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
            var allergy = logic.Get(VisitId);
            if (allergy != null)
            {
                return Ok(allergy);
            }
            else
            {
                return BadRequest("No Details Found");
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
