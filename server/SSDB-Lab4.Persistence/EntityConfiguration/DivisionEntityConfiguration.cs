using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
    }
}