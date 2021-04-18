using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackathonAPI.Models;
namespace HackathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberMajorController : ControllerBase
    {
        [HttpPut("{id}")]
        public ActionResult Put(long id, Members members)
        {
            if (id != members.Id)
            {
                return BadRequest();
            }
            try
            {
                string query = $"update medlemmer SET studie = '{members.Major}' WHERE id = {id}";
                dbStuff.updateDB(query);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("percentDATAING")]
        public ActionResult<PercentOfDATAING> Get()
        {
            try
            {
                int DATAINGs = dbStuff.getNumberOfMajorStudents(majors.DATAING);
                int total = dbStuff.getNumberOfMembers();
                //int percentage = DATAINGs / total;
                return Ok(DATAINGs);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
    public class PercentOfDATAING
    {
        public int percentageOfDATAING { get; set; }
    }
    public enum majors
    {
        DATAING,
        ELEKING,
        MASKING,
        ANNET
    }
}
