using FilmClub.Entity.Films;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.prersistance.Films
{
    public class FilmEntityMap : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Films");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
            builder.Property(f => f.Description).HasMaxLength(1000);
            builder.Property(f => f.Title).HasMaxLength(60).IsRequired();
            builder.Property(f => f.DurationPerMinuts).IsRequired();
            builder.Property(f => f.GenreId).IsRequired();
            builder.Property(f => f.LimitatedAge).IsRequired();
            builder.Property(f => f.CreatedYear).IsRequired();
            builder.OwnsOne(f=>f.Amount)
                .Property(a=>a.Price).IsRequired();
            builder.OwnsOne(f => f.Amount)
               .Property(a => a.DelayPenaltyPersantage).IsRequired();
            builder.OwnsOne(f => f.Amount)
               .Property(a => a.RentPrice).IsRequired();
        }
    }
}
