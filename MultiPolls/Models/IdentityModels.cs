﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace MultiPolls.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationUser : IdentityUser
    {
        public override string Email { get; set; }
    }

    public class MainDbContext : IdentityDbContext<ApplicationUser>
    {
        public MainDbContext()
            : base("DefaultConnection")
        {
        }
    }
}