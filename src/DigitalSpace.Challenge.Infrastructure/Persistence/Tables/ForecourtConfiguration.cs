using DigitalSpace.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Tables;

public class ForecourtConfiguration : IEntityTypeConfiguration<Forecourt>
{
    public void Configure(EntityTypeBuilder<Forecourt> builder)
    {
        builder.ToTable(nameof(ChallengeDbContext.Forecourts));

        builder.HasKey(x => x.Id);
        builder
            .HasMany(x => x.Lanes)
            .WithOne(x => x.Forecourt)
            .HasForeignKey(x => x.ForecourtId);
    }
}