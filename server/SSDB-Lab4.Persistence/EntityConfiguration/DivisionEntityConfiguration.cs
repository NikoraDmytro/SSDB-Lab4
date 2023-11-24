using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSDB_Lab4.Common;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.EntityConfiguration;

public class DivisionEntityConfiguration
    : IEntityTypeConfiguration<Division>
{
    public void Configure(EntityTypeBuilder<Division> builder)
    {
        builder.ToTable("divisions",
            t =>
            {
                t.HasCheckConstraint("CHK_divisions_sex",
                    "sex IN ('M', 'F')");
                t.HasCheckConstraint("CHK_divisions_weight",
                    "min_weight IS NOT NULL OR  max_weight IS NOT NULL");
            });
        
        builder.HasKey(d => d.Id);
        
        builder
            .Property(d => d.Id)
            .HasColumnName("division_id");
        
        builder
            .HasIndex(d => d.Name)
            .IsUnique();
        
        builder
            .Property(d => d.MinWeight)
            .HasColumnName("min_weight")
            .IsRequired(false);

        builder
            .Property(d => d.MaxWeight)
            .HasColumnName("max_weight")
            .IsRequired(false);

        builder
            .Property(d => d.MinAge)
            .HasColumnName("min_age")
            .IsRequired();
        
        builder
            .Property(d => d.MaxAge)
            .HasColumnName("max_age")
            .IsRequired();

        builder
            .Property(d => d.Sex)
            .HasMaxLength(1)
            .HasColumnName("sex")
            .HasColumnType("varchar(1)")
            .HasConversion<string>()
            .IsRequired();

        builder.HasData(
            new Division {
                Id = 1,
                Name = "Дівчата 11-13 років -35кг",
                MinWeight = 30.0, 
                MaxWeight = 35.0, 
                MinAge = 11, 
                MaxAge = 13, 
                Sex = Sex.F
            },
            new Division {
                Id = 2,
                Name = "Юніори 14-15 років -45кг",
                MinWeight = null, 
                MaxWeight = 45.0, 
                MinAge = 14, 
                MaxAge = 15, 
                Sex = Sex.M
            },
            new Division {
                Id = 3,
                Name = "Юніори 14-15 років -50кг",
                MinWeight = 45.0, 
                MaxWeight = 50.0, 
                MinAge = 14, 
                MaxAge = 15, 
                Sex = Sex.M
            },
            new Division {
                Id = 4,
                Name = "Юніори 16-17 років -57кг",
                MinWeight = 51.0, 
                MaxWeight = 57.0, 
                MinAge = 16, 
                MaxAge = 17, 
                Sex = Sex.M
            },
            new Division {
                Id = 5,
                Name = "Жінки 18-39 років -62кг",
                MinWeight = 57.0, 
                MaxWeight = 62.0, 
                MinAge = 18, 
                MaxAge = 39, 
                Sex = Sex.F
            },
            new Division {
                Id = 6,
                Name = "Чоловіки 18-39 років -64кг",
                MinWeight = 58.0, 
                MaxWeight = 64.0, 
                MinAge = 18, 
                MaxAge = 39, 
                Sex = Sex.M
            }
        );
    }
}