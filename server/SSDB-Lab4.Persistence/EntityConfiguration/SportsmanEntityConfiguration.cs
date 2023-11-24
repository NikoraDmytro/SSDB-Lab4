using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
    }
}