using DigitalSpace.Challenge.Domain.Entities;
using DigitalSpace.Challenge.Domain.Entities.Vehicles;
using DigitalSpace.Challenge.Infrastructure.Persistence.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DigitalSpace.Challenge.Infrastructure.Persistence;

public class ChallengeDbContext : DbContext
{
    public DbSet<Forecourt> Forecourts { get; set; } = null!;
    public DbSet<Lane> Lanes { get; set; } = null!;
    public DbSet<Pump> Pumps { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<Transaction> Transactions { get; set; } = null!;

    public ChallengeDbContext(DbContextOptions<ChallengeDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ForecourtConfiguration());
        modelBuilder.ApplyConfiguration(new LaneConfiguration());
        modelBuilder.ApplyConfiguration(new PumpConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
        
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties().Where(x => x.IsPrimaryKey()))
            {
                property.ValueGenerated = ValueGenerated.Never;
            }
        }
    }
}