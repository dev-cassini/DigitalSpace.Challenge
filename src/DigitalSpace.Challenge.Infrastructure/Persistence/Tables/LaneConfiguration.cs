using DigitalSpace.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Tables;

public class LaneConfiguration : IEntityTypeConfiguration<Lane>
{
    public void Configure(EntityTypeBuilder<Lane> builder)
    {
        builder.ToTable(nameof(ChallengeDbContext.Lanes));

        builder.HasKey(x => x.Id);
        builder
            .HasMany(x => x.Pumps)
            .WithOne(x => x.Lane)
            .HasForeignKey(x => x.LaneId);
    }
}