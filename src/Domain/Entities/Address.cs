namespace Domain.Entities;

public class Address
{
    public Guid Id { get; private set; }
    public string? Street { get; private set; }
    public string? Number { get; private set; }
    public string? Neighborhood { get; private set; }
    public string? City { get; private set; }
    public string? Estate { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public bool Active { get; private set; }
    public Guid ClientId { get; private set; }
    public Client? Client { get; private set; }
    
    public static Address Create(string? street, string? number, string? neighborhood, string? city, string? estate, Guid clientId, Guid id = default)
    {
        return new Address
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            Street = street,
            Number = number,
            Neighborhood = neighborhood,
            City = city,
            Estate = estate,
            CreatedAt = DateTime.UtcNow,
            Active = true,
            ClientId = clientId
        };
    }

    public static Address Update(Address item, string? street, string? number, string? neighborhood, string? city, string? Estate)
    {
        item.Street = street;
        item.Number = number;
        item.Neighborhood = neighborhood;
        item.City = city;
        item.Estate = Estate;
        item.UpdatedAt = DateTime.UtcNow;

        return item;
    }   

    public static Address Delete(Address item)
    {
        item.DeletedAt = DateTime.UtcNow;
        item.Active = false;

        return item;
    }      
}