namespace Application.Common.Dtos;

public record ClientDto(Guid Id, string? Name, string? Surname, int Age, string? Email);