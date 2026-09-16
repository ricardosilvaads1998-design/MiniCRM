using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniCRM.Models;

namespace MiniCRM.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; } 
    }
}
