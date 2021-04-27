using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelAgent.Models;

namespace TravelAgent.DataAccess
{
    // https://docs.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-5.0&tabs=visual-studio
    public class TravelAgentContext : DbContext
    {
        public TravelAgentContext(DbContextOptions<TravelAgentContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().ToTable("TodoItem");
            modelBuilder.Entity<Tourist>().ToTable("Tourist");
            modelBuilder.Entity<Stores>().ToTable("Stores");

        }

        public DbSet<TravelAgent.Models.Tourist> Tourist { get; set; }

        public DbSet<TravelAgent.Models.Stores> Stores { get; set; }
    }
}
