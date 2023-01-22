using HelloAngularApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelloAngularApp.Models.Context;

public sealed class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Product> Products { get; set; }
}