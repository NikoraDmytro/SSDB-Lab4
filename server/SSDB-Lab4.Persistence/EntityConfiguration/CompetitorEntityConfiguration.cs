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
            .WithMany(s => s.Competitors)
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

        builder.HasData(
            new Competitor { 
                Id = 1,
                SportsmanId = 1,
                CompetitionId = 1,
                WeightingResult = 54.0,
                DivisionId = 4,
                LapNum = 3
            },
            new Competitor { 
                Id = 2,
                SportsmanId = 2,
                CompetitionId = 1,
                WeightingResult = 54.0,
                DivisionId = 4,
                LapNum = 1
            },
            new Competitor { 
                Id = 3,
                SportsmanId = 3,
                CompetitionId = 1,
                WeightingResult = 55.0,
                DivisionId = 4,
                LapNum = 2
            },
            new Competitor { 
                Id = 4,
                SportsmanId = 4,
                CompetitionId = 1,
                WeightingResult = 44.0,
                DivisionId = 2,
                LapNum = 2
            },
            new Competitor { 
                Id = 5,
                SportsmanId = 5,
                CompetitionId = 1,
                WeightingResult = 43.0,
                DivisionId = 2,
                LapNum = 1
            },
            new Competitor { 
                Id = 6,
                SportsmanId = 6,
                CompetitionId = 2,
                WeightingResult = 46.0,
                DivisionId = 3,
                LapNum = 3
            },
            new Competitor { 
                Id = 7,
                SportsmanId = 7,
                CompetitionId = 2,
                WeightingResult = 47.0,
                DivisionId = 3,
                LapNum = 1
            },
            new Competitor { 
                Id = 8,
                SportsmanId = 8,
                CompetitionId = 2,
                WeightingResult = 48.0,
                DivisionId = 3,
                LapNum = 2
            },
            new Competitor { 
                Id = 9,
                SportsmanId = 9,
                CompetitionId = 3,
                WeightingResult = 34.0,
                DivisionId = 1,
                LapNum = 1
            },
            new Competitor { 
                Id = 10,
                SportsmanId = 10,
                CompetitionId = 3,
                WeightingResult = 35.0,
                DivisionId = 1,
                LapNum = 2
            },
            new Competitor { 
                Id = 11,
                SportsmanId = 1,
                CompetitionId = 4,
                WeightingResult = 54.0,
                DivisionId = 4,
                LapNum = 2
            },
            new Competitor { 
                Id = 12,
                SportsmanId = 2,
                CompetitionId = 4,
                WeightingResult = 54.0,
                DivisionId = 4,
                LapNum = 1
            },
            new Competitor { 
                Id = 13,
                SportsmanId = 4,
                CompetitionId = 5,
                WeightingResult = 42.0,
                DivisionId = 2,
                LapNum = 4
            },
            new Competitor { 
                Id = 14,
                SportsmanId = 5,
                CompetitionId = 5,
                WeightingResult = 42.0,
                DivisionId = 2,
                LapNum = 1
            },
            new Competitor { 
                Id = 15,
                SportsmanId = 6,
                CompetitionId = 5,
                WeightingResult = 44.0,
                DivisionId = 2,
                LapNum = 1
            },
            new Competitor { 
                Id = 16,
                SportsmanId = 7,
                CompetitionId = 5,
                WeightingResult = 45.0,
                DivisionId = 2,
                LapNum = 3
            },
            new Competitor { 
                Id = 17,
                SportsmanId = 8,
                CompetitionId = 5,
                WeightingResult = 45.0,
                DivisionId = 2,
                LapNum = 2
            },
            new Competitor { 
                Id = 18,
                SportsmanId = 9,
                CompetitionId = 4,
                WeightingResult = 34.0,
                DivisionId = 1,
                LapNum = 1
            },
            new Competitor { 
                Id = 19,
                SportsmanId = 10,
                CompetitionId = 4,
                WeightingResult = 35.0,
                DivisionId = 1,
                LapNum = 2
            }
        );
    }
}