using Microsoft.EntityFrameworkCore;
using WebApplicationBasic.Models;

namespace WebApplicationBasic.Data;

public class ApiDbContext:DbContext
{
    public DbSet<Driver> Drivers { get; set; }
    public ApiDbContext (DbContextOptions<ApiDbContext> options)
        :base (options)
    {
    }
}