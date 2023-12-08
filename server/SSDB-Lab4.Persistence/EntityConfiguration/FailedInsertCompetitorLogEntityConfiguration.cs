using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.EntityConfiguration;

public class FailedInsertCompetitorLogEntityConfiguration
:IEntityTypeConfiguration<FailedInsertCompetitorLog>
{
    public void Configure(EntityTypeBuilder<FailedInsertCompetitorLog> builder)
    {
        builder.ToTable("failed_insert_competitor_logs");

        builder.HasKey(l => l.Id);

        builder
            .Property(cl => cl.Id)
            .HasColumnName("id");
        
        builder
            .Property(cl => cl.FailedAt)
            .HasColumnName("failed_at")
            .IsRequired();
        
        builder
            .Property(l => l.SportsmanId)
            .HasColumnName("sportsman_id")
            .IsRequired();
        
        builder
            .Property(l => l.CompetitionId)
            .HasColumnName("competition_id")
            .IsRequired();

        builder
            .HasOne(l => l.Sportsman)
            .WithMany()
            .HasForeignKey(l => l.SportsmanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(l => l.Competition)
            .WithMany()
            .HasForeignKey(l => l.CompetitionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}