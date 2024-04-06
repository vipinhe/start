namespace Domain.Entities;

public class Address
{
    public Guid Id { get; set; }
    public string? Street { get; set; }
    public string? Number { get; set; }
    public string? Neighborhood { get; set; }
    public string? City { get; set; }
    public string? Estate { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public bool Active { get; private set; }

    public static Address Create(string? street, string? number, string? neighborhood, string? city, string? Estate)
    {
        return new Address
        {
            Id = Guid.NewGuid(),
            Street = street,
            Number = number,
            Neighborhood = neighborhood,
            City = city,
            Estate = Estate,
            CreatedAt = DateTime.UtcNow,
            Active = true
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