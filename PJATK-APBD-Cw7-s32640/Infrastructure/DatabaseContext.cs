using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_sxxxxx.Models;

namespace PJATK_APBD_Cw7_sxxxxx.Infrastrucutre;

public class DatabaseContext(DbContextOptions<DatabaseContext> opt) : DbContext(opt)
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
        
        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType
            {
                Id = 1,
                Abbreviation = "CPU",
                Name = "Processor"
            },
            new ComponentType
            {
                Id = 2,
                Abbreviation = "GPU",
                Name = "Graphics Card"
            },
            new ComponentType
            {
                Id = 3,
                Abbreviation = "RAM",
                Name = "Memory"
            }
        );

        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer
            {
                Id = 1,
                Abbreviation = "INT",
                FullName = "Intel Corporation",
                foundationDate = new DateTime(1968, 7, 18)
            },
            new ComponentManufacturer
            {
                Id = 2,
                Abbreviation = "NVDA",
                FullName = "NVIDIA Corporation",
                foundationDate = new DateTime(1993, 4, 5)
            },
            new ComponentManufacturer
            {
                Id = 3,
                Abbreviation = "CR",
                FullName = "Corsair",
                foundationDate = new DateTime(1994, 1, 1)
            }
        );

        modelBuilder.Entity<Component>().HasData(
            new Component
            {
                Code = "CPU001",
                Name = "Intel i7",
                Description = "14th generation processor",
                ComponentManufacturerId = 1,
                ComponentTypeId = 1
            },
            new Component
            {
                Code = "GPU001",
                Name = "RTX 4070",
                Description = "Gaming graphics card",
                ComponentManufacturerId = 2,
                ComponentTypeId = 2
            },
            new Component
            {
                Code = "RAM001",
                Name = "Corsair 16GB",
                Description = "DDR5 memory",
                ComponentManufacturerId = 3,
                ComponentTypeId = 3
            }
        );

        modelBuilder.Entity<PC>().HasData(
            new PC
            {
                Id = 1,
                Name = "Gaming Beast",
                Weight = 8.5f,
                Warranty = 36,
                CreatedAt = new DateTime(2026,1,10),
                Stock = 10
            },
            new PC
            {
                Id = 2,
                Name = "Office Pro",
                Weight = 6.2f,
                Warranty = 24,
                CreatedAt = new DateTime(2026,2,15),
                Stock = 15
            },
            new PC
            {
                Id = 3,
                Name = "Workstation X",
                Weight = 9.1f,
                Warranty = 48,
                CreatedAt = new DateTime(2026,3,20),
                Stock = 5
            }
        );

        modelBuilder.Entity<PCsComponent>().HasData(
            new PCsComponent
            {
                PcId = 1,
                ComponentCode = "CPU001",
                Amount = 1
            },
            new PCsComponent
            {
                PcId = 1,
                ComponentCode = "GPU001",
                Amount = 1
            },
            new PCsComponent
            {
                PcId = 1,
                ComponentCode = "RAM001",
                Amount = 2
            },
            new PCsComponent
            {
                PcId = 2,
                ComponentCode = "CPU001",
                Amount = 1
            },
            new PCsComponent
            {
                PcId = 2,
                ComponentCode = "RAM001",
                Amount = 1
            },
            new PCsComponent
            {
                PcId = 3,
                ComponentCode = "CPU001",
                Amount = 1
            },
            new PCsComponent
            {
                PcId = 3,
                ComponentCode = "GPU001",
                Amount = 2
            }
        );
    }
}