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
    public class AvreageAgeController : ControllerBase
    {
        dbStuff db = new dbStuff();
        [HttpGet]
        public ActionResult<AvreageAge> Get()
        {
            try
            {
                return Ok(db.getAvreageAge());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
