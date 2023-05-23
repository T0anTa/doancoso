using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOANCOSO.Identity
{
    public class AppUser : IdentityUser
    {
        public DateTime? Birthday { get; set; }
        public String Address { get; set; }
    }
}