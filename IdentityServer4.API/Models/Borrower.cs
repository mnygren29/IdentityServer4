using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer4.API.Models
{
    public class Borrower
    {
        public long Id { get; set; }
        public string BorrowerFirstName { get; set; }
        public string BorrowerLastName { get; set; }
    }
}
