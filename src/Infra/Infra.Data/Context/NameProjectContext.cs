using Microsoft.EntityFrameworkCore;
using NameProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Context
{
    public class NameProjectContext : DbContext
    {
        public NameProjectContext(DbContextOptions<NameProjectContext> options)
            : base(options)
        {

        }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
