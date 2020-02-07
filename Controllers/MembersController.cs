using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BSSLNCSApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSSLNCSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        public  class MemberViewModel
        {
            public string MembersId { get; set; }
            public string Name { get; set; }
            public string Status { get; set; }
        }

        private readonly Models.AppContext context;

        public MembersController(Models.AppContext _context)
        {
            context = _context;
        }

        [HttpPost("SendNewMember")]
        public IActionResult PostMember([FromBody] MemberViewModel member)
        {
            var mm = new Member
            {
                MembersId = member.MembersId,
                Name = member.Name,
                Status = member.Status
            };


        }
    }
}