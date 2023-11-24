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

        builder.HasData(
            new Competition
            {
                Id = 1,
                Name = "Кубок України серед старших юнаків, юніорів, дорослих",
                StartDate = new DateTime(2022, 02, 04),
                Duration = 2,
                City = "Черкаси"
            },
            new Competition
            {
                Id = 2,
                Name = "Чемпіонат України серед старших юнаків, юніорів, дорослих",
                StartDate = new DateTime(2023, 02, 16),
                Duration = 3,
                City = "Вінниця"
            },
            new Competition
            {
                Id = 3,
                Name = "Чемпіонат Вінницької області",
                StartDate = new DateTime(2023, 02, 03),
                Duration = 2,
                City = "Вінниця"
            },
            new Competition
            {
                Id = 4,
                Name = "Чемпіонат Дніпровської області",
                StartDate = new DateTime(2023, 01, 28),
                Duration = 1,
                City = "Дніпро"
            },
            new Competition
            {
                Id = 5,
                Name = "Відкритий Кубок Полтавської області",
                StartDate = new DateTime(2022, 12, 10),
                Duration = 1,
                City = "Полтава"
            },
            new Competition
            {
                Id = 6,
                Name = "Відкритий кубок міста Вінниці",
                StartDate = new DateTime(2022, 12, 09),
                Duration = 2,
                City = "Вінниця"
            },
            new Competition
            {
                Id = 7,
                Name = "Відкритий турнір СК \"Прайд\"",
                StartDate = new DateTime(2022, 04, 23),
                Duration = 1,
                City = "Запоріжжя"
            }
        );
    }
}