namespace Application.Queries.Client.GetClient;

public record GetClientQueryViewModel(OperationResult OperationResult, ClientDto? ClientDto = default);