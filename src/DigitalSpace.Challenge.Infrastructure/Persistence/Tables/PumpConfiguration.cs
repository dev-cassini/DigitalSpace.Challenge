using DigitalSpace.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Tables;

public class PumpConfiguration : IEntityTypeConfiguration<Pump>
{
    public void Configure(EntityTypeBuilder<Pump> builder)
    {
        builder.ToTable(nameof(ChallengeDbContext.Pumps));

        builder.HasKey(x => x.Id);
    }
}