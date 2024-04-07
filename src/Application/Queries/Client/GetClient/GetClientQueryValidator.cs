namespace Application.Queries.Client.GetClient;

public class GetClientQueryValidator : AbstractValidator<GetClientQuery>
{
    public GetClientQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}