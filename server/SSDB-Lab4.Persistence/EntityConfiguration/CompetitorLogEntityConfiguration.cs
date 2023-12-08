using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.EntityConfiguration;

public class CompetitorLogEntityConfiguration
:IEntityTypeConfiguration<CompetitorLog>
{
    public void Configure(EntityTypeBuilder<CompetitorLog> builder)
    {
        builder.ToTable("competitor_logs");

        builder.HasKey(cl => cl.Id);

        builder
            .Property(cl => cl.Id)
            .HasColumnName("id");
        
        builder
            .Property(cl => cl.ModifiedAt)
            .HasColumnName("modified_at")
            .IsRequired();
        
        builder
            .Property(cl => cl.CompetitorId)
            .HasColumnName("competitor_id")
            .IsRequired();

        builder
            .HasOne(cl => cl.Competitor)
            .WithMany()
            .HasForeignKey(cl => cl.CompetitorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}