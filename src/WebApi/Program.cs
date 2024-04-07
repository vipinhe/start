var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/clients/{id:guid}", async (ISender sender, Guid id) =>
{
    var result = await sender.Send(new GetClientQuery(id));

    return result.OperationResult switch
    {
        OperationResult.Failed => Results.BadRequest(result),
        OperationResult.Success => Results.Ok(result),
        OperationResult.NotFound => Results.NotFound(result)
    };
});

app.MapPost("/clients/", async (ISender sender, [FromBody] CreateClientCommand request) =>
{
    var result = await sender.Send(request);

    return result switch
    {
        OperationResult.Failed => Results.BadRequest(result),
        OperationResult.Success => Results.Ok(result),
        OperationResult.NotFound => Results.NotFound(result)
    };
});

app.Run();