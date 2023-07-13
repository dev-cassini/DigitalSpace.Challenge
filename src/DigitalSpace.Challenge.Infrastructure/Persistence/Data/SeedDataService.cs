using DigitalSpace.Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Data;

public class SeedDataService
{
    private readonly ChallengeDbContext _dbContext;

    public SeedDataService(ChallengeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void ClearDb()
    {
        _dbContext.Transactions.ExecuteDelete();
        _dbContext.Forecourts.ExecuteDelete();
        _dbContext.Vehicles.ExecuteDelete();
    }

    public void Execute()
    {
        var forecourt = new Forecourt(Guid.NewGuid());

        var lane1 = new Lane(Guid.NewGuid(), forecourt);
        var lane2 = new Lane(Guid.NewGuid(), forecourt);
        var lane3 = new Lane(Guid.NewGuid(), forecourt);
        
        var pump1 = new Pump(Guid.NewGuid(), lane1);
        var pump2 = new Pump(Guid.NewGuid(), lane1);
        var pump3 = new Pump(Guid.NewGuid(), lane1);
        var pump4 = new Pump(Guid.NewGuid(), lane2);
        var pump5 = new Pump(Guid.NewGuid(), lane2);
        var pump6 = new Pump(Guid.NewGuid(), lane2);
        var pump7 = new Pump(Guid.NewGuid(), lane3);
        var pump8 = new Pump(Guid.NewGuid(), lane3);
        var pump9 = new Pump(Guid.NewGuid(), lane3);
        
        lane1.AddPump(pump1);
        lane1.AddPump(pump2);
        lane1.AddPump(pump3);
        
        lane2.AddPump(pump4);
        lane2.AddPump(pump5);
        lane2.AddPump(pump6);
        
        lane3.AddPump(pump7);
        lane3.AddPump(pump8);
        lane3.AddPump(pump9);
        
        forecourt.AddLane(lane1);
        forecourt.AddLane(lane2);
        forecourt.AddLane(lane3);

        _dbContext.Forecourts.Add(forecourt);
        _dbContext.SaveChanges();
    }
}