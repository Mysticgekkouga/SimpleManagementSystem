using Microsoft.EntityFrameworkCore;
using SimpleManagementSystem.Models;

namespace SimpleManagementSystem.Data
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions options)
            : base(options)
        {
        }
        
        public DbSet<Device> Devices { get; set; }
    }
}