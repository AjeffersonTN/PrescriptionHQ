using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrescriptionHQ.Models;

namespace PrescriptionHQ.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Refill> Refill { get; set; }
        public DbSet<Pharmacy> Pharmacy { get; set; }
    }
}
