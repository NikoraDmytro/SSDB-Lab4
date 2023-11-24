using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.EntityConfiguration;

public class CompetitorEntityConfiguration
    : IEntityTypeConfiguration<Competitor>
{
    public void Configure(EntityTypeBuilder<Competitor> builder)
    {
        builder.ToTable("competitors");
        
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasColumnName("competitor_id");
        
        builder
            .Property(c => c.WeightingResult)
            .HasColumnName("weighting_result")
            .IsRequired(false);

        builder
            .Property(c => c.LapNum)
            .HasColumnName("lap_num")
            .HasDefaultValue(1);
        
        builder
            .Property(c => c.SportsmanId)
            .HasColumnName("sportsman_id")
            .IsRequired();

        builder
            .HasOne(c => c.Sportsman)
            .WithMany()
            .HasForeignKey(c => c.SportsmanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(c => c.CompetitionId)
            .HasColumnName("competition_id")
            .IsRequired();

        builder
            .HasOne(c => c.Competition)
            .WithMany(c => c.Competitors)
            .HasForeignKey(c => c.CompetitionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .Property(c => c.DivisionId)
            .HasColumnName("division_id")
            .IsRequired(false);

        builder
            .HasOne(c => c.Division)
            .WithMany()
            .HasForeignKey(c => c.DivisionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}