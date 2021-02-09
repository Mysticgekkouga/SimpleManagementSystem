using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleManagementSystem.Models;

namespace SimpleManagementSystem.Data
{
    public class ManagementContext : IdentityDbContext<IdentityUser>
    {
        public ManagementContext(DbContextOptions options)
            : base(options)
        {
        }
        
        public DbSet<Device> Devices { get; set; }
    }
}