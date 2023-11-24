using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSDB_Lab4.Common;
using SSDB_Lab4.Domain.entities;

namespace SSDB_Lab4.Persistence.EntityConfiguration;

public class SportsmanEntityConfiguration
    : IEntityTypeConfiguration<Sportsman>
{
    public void Configure(EntityTypeBuilder<Sportsman> builder)
    {
        builder.ToTable("sportsmen",
            t =>
                t.HasCheckConstraint("CHK_sportsmen_sex", "sex IN ('M', 'F')"));

        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Id)
            .HasColumnName("sportsman_id");

        builder
            .Property(s => s.BirthDate)
            .HasColumnName("birth_date")
            .IsRequired();

        builder
            .Property(s => s.Sex)
            .HasColumnName("sex")
            .HasMaxLength(1)
            .HasColumnType("varchar(1)")
            .HasConversion<string>()
            .IsRequired();

        builder
            .Property(s => s.FirstName)
            .HasColumnName("first_name")
            .IsRequired();

        builder
            .Property(s => s.LastName)
            .HasColumnName("last_name")
            .IsRequired();

        builder.HasData(
            new Sportsman
            {
                Id = 1,
                LastName = "Жадан",
                FirstName = "Вадим",
                BirthDate = new DateTime(2007, 7, 29),
                Sex = Sex.M
            },
            new Sportsman
            {
                Id = 2,
                LastName = "Безкровний",
                FirstName = "Владислав",
                BirthDate = new DateTime(2007, 7, 06),
                Sex = Sex.M
            },
            new Sportsman
            {
                Id = 3,
                LastName = "Солдатенко",
                FirstName = "Руслан",
                BirthDate = new DateTime(2007, 6, 28),
                Sex = Sex.M
            },
            new Sportsman
            {
                Id = 4,
                LastName = "Белькевич",
                FirstName = "Дмитро",
                BirthDate = new DateTime(2009, 6, 30),
                Sex = Sex.M
            },
            new Sportsman
            {
                Id = 5,
                LastName = "Савко",
                FirstName = "Данило",
                BirthDate = new DateTime(2008, 7, 30),
                Sex = Sex.M
            },
            new Sportsman
            {
                Id = 6,
                LastName = "Баштан",
                FirstName = "Андрій",
                BirthDate = new DateTime(2009, 3, 02),
                Sex = Sex.M
            },
            new Sportsman
            {
                Id = 7,
                LastName = "Кондратюк",
                FirstName = "Роман",
                BirthDate = new DateTime(2009, 7, 01),
                Sex = Sex.M
            },
            new Sportsman
            {
                Id = 8,
                LastName = "Наливайко",
                FirstName = "Євген",
                BirthDate = new DateTime(2008, 7, 21),
                Sex = Sex.M
            },
            new Sportsman
            {
                Id = 9,
                LastName = "Шишацька",
                FirstName = "Анна",
                BirthDate = new DateTime(2012, 11, 25),
                Sex = Sex.F
            },
            new Sportsman
            {
                Id = 10,
                LastName = "Неділько",
                FirstName = "Галина",
                BirthDate = new DateTime(2011, 03, 23),
                Sex = Sex.F
            }
        );
    }
}