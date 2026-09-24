using System.Security.Cryptography.X509Certificates;
using ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Data;

public class AppDbContext : DbContext
{
    public  AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    public DbSet<Category> Categories {get; set;}
}