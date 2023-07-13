using DigitalSpace.Challenge.Domain.Entities.Vehicles;
using DigitalSpace.Challenge.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Tables;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable(nameof(ChallengeDbContext.Vehicles));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Type);
        builder.Property(x => x.FuelType);
        builder.Property(x => x.FuelLevel);
        builder.Property(x => x.TankCapacity);

        builder
            .HasDiscriminator(x => x.Type)
            .HasValue<Car>(VehicleType.Car)
            .HasValue<Van>(VehicleType.Van)
            .HasValue<Hgv>(VehicleType.Hgv);
    }
}