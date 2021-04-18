using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonAPI.Models
{
    public class Members
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Major { get; set; }
        public string Degree { get; set; }
        public int Admin { get; set; }
        public string Pwd { get; set; }
        public string Regdate { get; set; }
        public int BirthYear { get; set; }
    }
}
