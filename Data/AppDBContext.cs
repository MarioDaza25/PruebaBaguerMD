using Microsoft.EntityFrameworkCore;
using PruebaBaguerMD.Models;

namespace PruebaBaguerMD.Data;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
    }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        
 }

