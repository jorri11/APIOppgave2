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
        dbStuff db = new dbStuff();
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
                db.updateDB(query);
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
                float DATAINGs =(float)db.getNumberOfMajorStudents(majors.DATAING);
                float total = (float)db.getNumberOfMembers();
                float percentage = (DATAINGs / total)*100;
                return Ok(percentage);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
    public class PercentOfDATAING
    {
        public float percentageOfDATAING { get; set; }
    }
    public enum majors
    {
        DATAING,
        ELEKING,
        MASKING,
        ANNET
    }
}
