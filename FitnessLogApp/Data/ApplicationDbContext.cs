using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FitnessLogApp.Models;

namespace FitnessLogApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<FitnessLogApp.Models.Exercise> Exercise { get; set; } = default!;

    public DbSet<FitnessLogApp.Models.Log> Log { get; set; } = default!;

   
}
