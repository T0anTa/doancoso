﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
namespace DOANCOSO.Identity
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("QuanLyBanSachModel") { }
    }
}