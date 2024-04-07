using Application.Common.Models;

namespace Infrastructure.Common.Context;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IConfiguration? _configuration;

    public DbSet<Client> Clients { get; set; }
    public DbSet<Address> Adresses { get; set; }

    public ApplicationDbContext(IConfiguration configuration) => _configuration = configuration;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        CreateSeedData();
        
        modelBuilder.ApplyConfiguration(new ClientMap());
        modelBuilder.ApplyConfiguration(new AddressMap());
        
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _configuration?.GetConnectionString("DefaultConnection");

        if (!optionsBuilder.IsConfigured)
        {
            // optionsBuilder.UseNpgsql(connectionString);
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }
    }

    public async Task<OperationResult> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken) > 0 ? OperationResult.Success : OperationResult.Failed;
    }
    
    private static void CreateSeedData()
    {
        var vitorId = Guid.NewGuid();
        var jonathanId = Guid.NewGuid();
        
        ClientMap.Clients =
        [
            Client.Create("Vitor", "Pinheiro", 30, "vitor.pinheiro@email.com", vitorId),
            Client.Create("Jonathan", "Peris", 32, "jonathan.peris@email.com", jonathanId)
        ];

        AddressMap.Addresses =
        [
            Address.Create("Avenida Paulista", "1057", "Bela Vista", "São Paulo", "São Paulo", vitorId)
        ];
    }
}