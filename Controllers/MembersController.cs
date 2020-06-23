using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BSSLNCSApi.Models;
using BSSLNCSApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSSLNCSApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        
        private readonly Models.DcNCSApiContext context;
        private readonly IUserService userService;
        public MembersController(Models.DcNCSApiContext _context, IUserService _userService)
        {
            context = _context;
            userService = _userService;
        }


        //[AllowAnonymous]
        //[HttpPost("authenticate")]
        //public IActionResult Authenticate([FromBody]AuthenticateModel model)
        //{
        //    var user = userService.Authenticate(model.CompCode, model.Password);

        //    if (user == null)
        //        return BadRequest(new { message = "Username or password is incorrect" });

        //    return Ok(user);
        //}

        /// <summary>
        /// To send new member registered
        /// </summary>
        /// <param name="member">Object containing the member id, name and status </param>
        /// <returns></returns>
        [HttpPost("NewMember")]
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

        /// <summary>
        /// To send new member registered
        /// </summary>
        /// <param name="member">Object containing the member id, name and status </param>
        /// <returns></returns>
        [HttpPost("NewTransaction")]
        public async Task<IActionResult> PostMemberTransaction([FromBody] MemberTransactionViewModel vm)
        {
            try
            {

                if (vm == null || !ModelState.IsValid)
                {
                    return BadRequest("Please input all required fields");
                }


                var mt = new MemberTransaction
                {
                    ActDate = vm.Date,
                    ActYear = vm.Year,
                    CrValue = vm.CrValue,
                    CustCode = vm.CustomerCode,
                    InvoiceAmount = vm.InvoiceAmount,
                    TransAmount = vm.TransAmount,
                    RecNo = $"NCS/INV/{DateTime.Today}/{DateTime.Now.ToString("00000")}"
                };


                context.MemberTransactions.Add(mt);

               await context.SaveChangesAsync();
                return Ok("Transaction saved");
            }
            catch (Exception ex)
            {
                return BadRequest($"Could not create transaction. {Environment.NewLine}{ex.Message}");
            }
        }
        public class MemberViewModel
        {
            [Required]
            public string MembersId { get; set; }
            [Required]
            public string MemberName { get; set; }
            [Required]
            public string Status { get; set; }
        }
        public class MemberTransactionViewModel
        {
            public DateTime? Date { get;  set; }
            public string Year { get;  set; }
            public string CustomerCode { get;  set; }
            public string CrValue { get;  set; }
            public string TransAmount { get;  set; }
            public string InvoiceAmount { get; set; }
        }
    }

    public class AuthenticateModel
    {
        [Required]
        public string CompCode { get; set; }

        [Required]
        public string Password { get; set; }
    }
}