using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.API.Models
{
    public class LoanContext : DbContext
    {

        public LoanContext(DbContextOptions<LoanContext> options)
            : base(options)
        {

        }

        public DbSet<Borrower> Borrower {get;set;}
    }
}
