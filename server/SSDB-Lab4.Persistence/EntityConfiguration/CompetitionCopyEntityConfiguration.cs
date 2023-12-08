using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.EntityConfiguration;

public class CompetitionCopyEntityConfiguration
    : IEntityTypeConfiguration<CompetitionCopy>
{
    public void Configure(EntityTypeBuilder<CompetitionCopy> builder)
    {
        builder.ToTable("competition_copies");

        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasColumnName("id");

        builder
            .Property(c => c.CompetitionId)
            .HasColumnName("competition_id")
            .IsRequired();
        
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
    }
}