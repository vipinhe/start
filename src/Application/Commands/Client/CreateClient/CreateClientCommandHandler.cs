namespace Application.Commands.Client.CreateClient;

public class CreateClientCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateClientCommand, OperationResult>
{
    public async ValueTask<OperationResult> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var client = Domain.Entities.Client.Create(request.Name, request.Surname, request.Age, request.Email);
        context.Clients.Add(client);

        var result = await context.SaveChangesAsync(cancellationToken);

        return result;
    }
}