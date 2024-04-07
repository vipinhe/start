namespace Application.Commands.Client.CreateClient;

public record CreateClientCommand(string? Name, string? Surname, int Age, string? Email) : IRequest<OperationResult>;