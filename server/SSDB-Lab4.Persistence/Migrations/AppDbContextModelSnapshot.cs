﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSDB_Lab4.Persistence;

#nullable disable

namespace SSDB_Lab4.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SSDB_Lab4.Domain.entities.Competition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("competition_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("city");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("duration");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date");

                    b.HasKey("Id");

                    b.HasIndex("Name", "StartDate")
                        .IsUnique();

                    b.ToTable("competitions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Черкаси",
                            Duration = 2,
                            Name = "Кубок України серед старших юнаків, юніорів, дорослих",
                            StartDate = new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            City = "Вінниця",
                            Duration = 3,
                            Name = "Чемпіонат України серед старших юнаків, юніорів, дорослих",
                            StartDate = new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            City = "Вінниця",
                            Duration = 2,
                            Name = "Чемпіонат Вінницької області",
                            StartDate = new DateTime(2023, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            City = "Дніпро",
                            Duration = 1,
                            Name = "Чемпіонат Дніпровської області",
                            StartDate = new DateTime(2023, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            City = "Полтава",
                            Duration = 1,
                            Name = "Відкритий Кубок Полтавської області",
                            StartDate = new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            City = "Вінниця",
                            Duration = 2,
                            Name = "Відкритий кубок міста Вінниці",
                            StartDate = new DateTime(2022, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            City = "Запоріжжя",
                            Duration = 1,
                            Name = "Відкритий турнір СК \"Прайд\"",
                            StartDate = new DateTime(2022, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("SSDB_Lab4.Domain.entities.Competitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("competitor_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompetitionId")
                        .HasColumnType("int")
                        .HasColumnName("competition_id");

                    b.Property<int?>("DivisionId")
                        .HasColumnType("int")
                        .HasColumnName("division_id");

                    b.Property<int>("LapNum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("lap_num");

                    b.Property<int>("SportsmanId")
                        .HasColumnType("int")
                        .HasColumnName("sportsman_id");

                    b.Property<double?>("WeightingResult")
                        .HasColumnType("float")
                        .HasColumnName("weighting_result");

                    b.HasKey("Id");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("DivisionId");

                    b.HasIndex("SportsmanId");

                    b.ToTable("competitors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompetitionId = 1,
                            DivisionId = 4,
                            LapNum = 3,
                            SportsmanId = 1,
                            WeightingResult = 54.0
                        },
                        new
                        {
                            Id = 2,
                            CompetitionId = 1,
                            DivisionId = 4,
                            LapNum = 1,
                            SportsmanId = 2,
                            WeightingResult = 54.0
                        },
                        new
                        {
                            Id = 3,
                            CompetitionId = 1,
                            DivisionId = 4,
                            LapNum = 2,
                            SportsmanId = 3,
                            WeightingResult = 55.0
                        },
                        new
                        {
                            Id = 4,
                            CompetitionId = 1,
                            DivisionId = 2,
                            LapNum = 2,
                            SportsmanId = 4,
                            WeightingResult = 44.0
                        },
                        new
                        {
                            Id = 5,
                            CompetitionId = 1,
                            DivisionId = 2,
                            LapNum = 1,
                            SportsmanId = 5,
                            WeightingResult = 43.0
                        },
                        new
                        {
                            Id = 6,
                            CompetitionId = 2,
                            DivisionId = 3,
                            LapNum = 3,
                            SportsmanId = 6,
                            WeightingResult = 46.0
                        },
                        new
                        {
                            Id = 7,
                            CompetitionId = 2,
                            DivisionId = 3,
                            LapNum = 1,
                            SportsmanId = 7,
                            WeightingResult = 47.0
                        },
                        new
                        {
                            Id = 8,
                            CompetitionId = 2,
                            DivisionId = 3,
                            LapNum = 2,
                            SportsmanId = 8,
                            WeightingResult = 48.0
                        },
                        new
                        {
                            Id = 9,
                            CompetitionId = 3,
                            DivisionId = 1,
                            LapNum = 1,
                            SportsmanId = 9,
                            WeightingResult = 34.0
                        },
                        new
                        {
                            Id = 10,
                            CompetitionId = 3,
                            DivisionId = 1,
                            LapNum = 2,
                            SportsmanId = 10,
                            WeightingResult = 35.0
                        },
                        new
                        {
                            Id = 11,
                            CompetitionId = 4,
                            DivisionId = 4,
                            LapNum = 2,
                            SportsmanId = 1,
                            WeightingResult = 54.0
                        },
                        new
                        {
                            Id = 12,
                            CompetitionId = 4,
                            DivisionId = 4,
                            LapNum = 1,
                            SportsmanId = 2,
                            WeightingResult = 54.0
                        },
                        new
                        {
                            Id = 13,
                            CompetitionId = 5,
                            DivisionId = 2,
                            LapNum = 4,
                            SportsmanId = 4,
                            WeightingResult = 42.0
                        },
                        new
                        {
                            Id = 14,
                            CompetitionId = 5,
                            DivisionId = 2,
                            LapNum = 1,
                            SportsmanId = 5,
                            WeightingResult = 42.0
                        },
                        new
                        {
                            Id = 15,
                            CompetitionId = 5,
                            DivisionId = 2,
                            LapNum = 1,
                            SportsmanId = 6,
                            WeightingResult = 44.0
                        },
                        new
                        {
                            Id = 16,
                            CompetitionId = 5,
                            DivisionId = 2,
                            LapNum = 3,
                            SportsmanId = 7,
                            WeightingResult = 45.0
                        },
                        new
                        {
                            Id = 17,
                            CompetitionId = 5,
                            DivisionId = 2,
                            LapNum = 2,
                            SportsmanId = 8,
                            WeightingResult = 45.0
                        },
                        new
                        {
                            Id = 18,
                            CompetitionId = 4,
                            DivisionId = 1,
                            LapNum = 1,
                            SportsmanId = 9,
                            WeightingResult = 34.0
                        },
                        new
                        {
                            Id = 19,
                            CompetitionId = 4,
                            DivisionId = 1,
                            LapNum = 2,
                            SportsmanId = 10,
                            WeightingResult = 35.0
                        });
                });

            modelBuilder.Entity("SSDB_Lab4.Domain.entities.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("division_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MaxAge")
                        .HasColumnType("int")
                        .HasColumnName("max_age");

                    b.Property<double?>("MaxWeight")
                        .HasColumnType("float")
                        .HasColumnName("max_weight");

                    b.Property<int>("MinAge")
                        .HasColumnType("int")
                        .HasColumnName("min_age");

                    b.Property<double?>("MinWeight")
                        .HasColumnType("float")
                        .HasColumnName("min_weight");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("sex");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("divisions", null, t =>
                        {
                            t.HasCheckConstraint("CHK_divisions_sex", "sex IN ('M', 'F')");

                            t.HasCheckConstraint("CHK_divisions_weight", "min_weight IS NOT NULL OR  max_weight IS NOT NULL");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MaxAge = 13,
                            MaxWeight = 35.0,
                            MinAge = 11,
                            MinWeight = 30.0,
                            Name = "Дівчата 11-13 років -35кг",
                            Sex = "F"
                        },
                        new
                        {
                            Id = 2,
                            MaxAge = 15,
                            MaxWeight = 45.0,
                            MinAge = 14,
                            Name = "Юніори 14-15 років -45кг",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 3,
                            MaxAge = 15,
                            MaxWeight = 50.0,
                            MinAge = 14,
                            MinWeight = 45.0,
                            Name = "Юніори 14-15 років -50кг",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 4,
                            MaxAge = 17,
                            MaxWeight = 57.0,
                            MinAge = 16,
                            MinWeight = 51.0,
                            Name = "Юніори 16-17 років -57кг",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 5,
                            MaxAge = 39,
                            MaxWeight = 62.0,
                            MinAge = 18,
                            MinWeight = 57.0,
                            Name = "Жінки 18-39 років -62кг",
                            Sex = "F"
                        },
                        new
                        {
                            Id = 6,
                            MaxAge = 39,
                            MaxWeight = 64.0,
                            MinAge = 18,
                            MinWeight = 58.0,
                            Name = "Чоловіки 18-39 років -64кг",
                            Sex = "M"
                        });
                });

            modelBuilder.Entity("SSDB_Lab4.Domain.entities.Sportsman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("sportsman_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasColumnName("last_name");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)")
                        .HasColumnName("sex");

                    b.HasKey("Id");

                    b.ToTable("sportsmen", null, t =>
                        {
                            t.HasCheckConstraint("CHK_sportsmen_sex", "sex IN ('M', 'F')");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(2007, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Вадим",
                            LastName = "Жадан",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(2007, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Владислав",
                            LastName = "Безкровний",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(2007, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Руслан",
                            LastName = "Солдатенко",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(2009, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Дмитро",
                            LastName = "Белькевич",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(2008, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Данило",
                            LastName = "Савко",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(2009, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Андрій",
                            LastName = "Баштан",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTime(2009, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Роман",
                            LastName = "Кондратюк",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 8,
                            BirthDate = new DateTime(2008, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Євген",
                            LastName = "Наливайко",
                            Sex = "M"
                        },
                        new
                        {
                            Id = 9,
                            BirthDate = new DateTime(2012, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Анна",
                            LastName = "Шишацька",
                            Sex = "F"
                        },
                        new
                        {
                            Id = 10,
                            BirthDate = new DateTime(2011, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Галина",
                            LastName = "Неділько",
                            Sex = "F"
                        });
                });

            modelBuilder.Entity("SSDB_Lab4.Domain.entities.Competitor", b =>
                {
                    b.HasOne("SSDB_Lab4.Domain.entities.Competition", "Competition")
                        .WithMany("Competitors")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSDB_Lab4.Domain.entities.Division", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SSDB_Lab4.Domain.entities.Sportsman", "Sportsman")
                        .WithMany("Competitors")
                        .HasForeignKey("SportsmanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Competition");

                    b.Navigation("Division");

                    b.Navigation("Sportsman");
                });

            modelBuilder.Entity("SSDB_Lab4.Domain.entities.Competition", b =>
                {
                    b.Navigation("Competitors");
                });

            modelBuilder.Entity("SSDB_Lab4.Domain.entities.Sportsman", b =>
                {
                    b.Navigation("Competitors");
                });
#pragma warning restore 612, 618
        }
    }
}
