using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GigFlow.Persistence.Contexts;

public class GigFlowDbContextFactory : IDesignTimeDbContextFactory<GigFlowDbContext>
{
    public GigFlowDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GigFlowDbContext>();
        
        optionsBuilder.UseSqlServer("Server=localhost,1435;Database=GigFlowDb;User Id=sa;Password=Password123*;TrustServerCertificate=True;");

        return new GigFlowDbContext(optionsBuilder.Options);
    }
}