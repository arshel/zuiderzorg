using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace zuiderzorg.Models
{
    public class CategoryContext :  DbContext
    {
        public DbSet<Category>? Categories { get; set; }
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    
}

    public class Category {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}