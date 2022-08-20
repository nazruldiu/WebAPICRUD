using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIFullCRUDWithFile.Entities.Entities;

namespace WebAPIFullCRUDWithFile.DataService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<UserModelEntity> Users { get; set; }
        public DbSet<UserDetailsEntity> UserDetails { get; set; }
    }
}
