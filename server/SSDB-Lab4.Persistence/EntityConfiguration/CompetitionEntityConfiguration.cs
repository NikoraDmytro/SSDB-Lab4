using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.EntityConfiguration;

public class CompetitionEntityConfiguration
    : IEntityTypeConfiguration<Competition>
{
    public void Configure(EntityTypeBuilder<Competition> builder)
    {
        builder.ToTable("competitions");

        builder.HasKey(c => c.Id);
        
        builder
            .Property(c => c.Id)
            .HasColumnName("competition_id");
        
        builder
            .Property(c => c.Name)
            .HasColumnName("name")
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired();
        
        builder
            .Property(c => c.StartDate)
            .HasColumnName("start_date")
            .IsRequired();
        
        builder
            .Property(c => c.Duration)
            .HasColumnName("duration")
            .IsRequired();
        
        builder
            .Property(c => c.City)
            .HasColumnType("varchar(60)")
            .HasMaxLength(60)
            .HasColumnName("city")
            .IsRequired();
        
        builder
            .HasIndex(c => new { c.Name, c.StartDate })
            .IsUnique();
    }
}