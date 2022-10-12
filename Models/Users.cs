using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
namespace zuiderzorg.PostgreSQL
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("server=localhost;Port=5432;Database=zuiderzorg;User Id=postgres;Password=Feliciano123!");
    
    

    public UserContext(DbContextOptions<UserContext> options): base(options) {

    }
}

    public class User {
        public int Id { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public string HashSalt { get; set; }
    }
}