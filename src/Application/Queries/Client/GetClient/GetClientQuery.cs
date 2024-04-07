namespace Application.Queries.Client.GetClient;

public record GetClientQuery(Guid Id) : IRequest<GetClientQueryViewModel>;