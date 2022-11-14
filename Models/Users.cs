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
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("server=localhost;Port=5432;Database=zuiderzorg;User Id=postgres;Password=1");
    
}

    public class User {
        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? HashPassword { get; set; }
        public string? HashSalt { get; set; }
    }
}