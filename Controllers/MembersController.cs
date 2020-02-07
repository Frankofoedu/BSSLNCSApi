using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            [Required]
            public string MembersId { get; set; }
            [Required]
            public string MemberName { get; set; }
            [Required]
            public string Status { get; set; }
        }

        private readonly Models.AppContext context;

        public MembersController(Models.AppContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// To send new member registered
        /// </summary>
        /// <param name="member">Object containing the member id, name and status </param>
        /// <returns></returns>
        [HttpPost("SendNewMember")]
        public async Task<IActionResult> PostMemberAsync([FromBody] MemberViewModel member)
        {
           
            try
            {
                if (member == null || !ModelState.IsValid)
                {
                    return BadRequest("Please input all required fields");
                }

                bool memberExists = context.Members.Any(x => x.MembersId == member.MembersId && x.Name == member.MemberName && x.Status == member.Status);
               
                if (memberExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, "data already exists");
                }


                var mm = new Member
                {
                    MembersId = member.MembersId,
                    Name = member.MemberName,
                    Status = member.Status
                };

                context.Members.Add(mm);


                await context.SaveChangesAsync();

                
            }
            catch (Exception ex)
            {
                return BadRequest("Could not create member");
            }

            return Ok(member);
        }



    }
}