using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace zuiderzorg.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User>? Users { get; set; }
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    
}

    public class User {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? HashPassword { get; set; }
        public string? HashSalt { get; set; }
    }
}