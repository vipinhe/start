namespace Application.Commands.Client.CreateClient;

public class CreateClienteCommandValidator : AbstractValidator<CreateClientCommand>
{
    public CreateClienteCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    
        RuleFor(x => x.Surname)
            .NotEmpty();
        
        RuleFor(x => x.Age)
            .Must(x => x >= 18)
            .WithMessage("Client have to be 18y older");
        
        RuleFor(x => x.Email)
            .EmailAddress();     
    }
}