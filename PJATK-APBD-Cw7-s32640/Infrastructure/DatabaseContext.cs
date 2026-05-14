using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_sxxxxx.Models;

namespace PJATK_APBD_Cw7_sxxxxx.Infrastrucutre;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<PCsComponent> PCsComponents { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PCsComponent>()
            .HasKey(pc => new { pc.PcId, pc.ComponentCode });
    }
}