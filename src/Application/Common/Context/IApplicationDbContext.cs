namespace Application.Common.Context;

public interface IApplicationDbContext
{
    DbSet<Client> Clients { get; set; }
    DbSet<Address> Adresses { get; set; }

    Task<OperationResult> SaveChangesAsync(CancellationToken cancellationToken = default);
}