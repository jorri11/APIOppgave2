using HackathonAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace HackathonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberOfMembersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<NumberOfMembers> Get()
        {
            try
            {
                int numberOfMembers = dbStuff.getNumberOfMembers();
                return Ok(new NumberOfMembers { numberOfMembers = numberOfMembers });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
