using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSLNCSApi.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

       
    }
}
