using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSSLNCSApi.Models
{
    public class DcNCSApiContext : DbContext
    {
        public DcNCSApiContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<MemberTransaction>  MemberTransactions { get; set; }
        public DbSet<AppUser> APIUsers { get; set; }
    }
}
