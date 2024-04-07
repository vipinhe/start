namespace Application.Queries.Client.GetClient;

public class GetClientQueryHandler(IApplicationDbContext context) : IRequestHandler<GetClientQuery, GetClientQueryViewModel>
{
    public async ValueTask<GetClientQueryViewModel> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        var client = await context.Clients
            .AsNoTracking()
            .Where(x => x.Id == request.Id && x.Active)
            .Select(x => x.MapToDto())
            .FirstOrDefaultAsync(cancellationToken);

        if (client is null)
        {
            return new GetClientQueryViewModel(OperationResult.NotFound);
        }

        return new GetClientQueryViewModel(OperationResult.Success, client);
    }
}