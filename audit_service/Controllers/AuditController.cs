//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Bussiness_Logic;
//using Models;
//using Microsoft.Data.SqlClient;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using audit_service.Entities;

namespace audit_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        AuditServiceContext auditServiceContext = new AuditServiceContext();

        [HttpPost("AddBloodGroup")]
        public IActionResult PostBloodGroup([FromBody] BloodGroupTable bloodGroupTable)
        {
            try
            {
                auditServiceContext.BloodGroupTables.Add(bloodGroupTable);
                auditServiceContext.SaveChanges();
                return Ok(bloodGroupTable);
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

        [HttpPost("AddBloodPressureDiastolic")]
        public IActionResult PostBloodPressureDiastolic([FromBody] BloodPressureDiastolicTable bloodPressureDiastolicTable)
        {
            try
            {
                auditServiceContext.BloodPressureDiastolicTables.Add(bloodPressureDiastolicTable);
                auditServiceContext.SaveChanges();
                return Ok(bloodPressureDiastolicTable);
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

        [HttpPost("AddBloodPressureSystolic")]

        public IActionResult PostBloodPressureSystolic([FromBody] BloodPressureSystolicTable bloodPressureSystolicTable)
        {
            try
            {
                auditServiceContext.BloodPressureSystolicTables.Add(bloodPressureSystolicTable);
                auditServiceContext.SaveChanges();
                return Ok(bloodPressureSystolicTable);
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

        [HttpPost("AddBodyTemperature")]
        public IActionResult PostBodyTemperature([FromBody] BodyTemperature bodyTemperature)
        {
            try
            {
                auditServiceContext.BodyTemperatures.Add(bodyTemperature);
                auditServiceContext.SaveChanges();
                return Ok(bodyTemperature);
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

        [HttpPost("AddHeight")]
        public IActionResult PostHeightTable([FromBody] HeightTable heightTable)
        {
            try
            {
                auditServiceContext.HeightTables.Add(heightTable);
                auditServiceContext.SaveChanges();
                return Ok(heightTable);
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

        [HttpPost("AddRespiration")]

        public IActionResult PostRespiration([FromBody] RespirationTable respirationTable)
        {
            try
            {
                auditServiceContext.RespirationTables.Add(respirationTable);
                auditServiceContext.SaveChanges();
                return Ok(respirationTable);
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

        [HttpPost("AddWeight")]

        public IActionResult PostWeight([FromBody] WeightTable weightTable)
        {
            try
            {
                auditServiceContext.WeightTables.Add(weightTable);
                auditServiceContext.SaveChanges();
                return Ok(weightTable);
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
    }
}


