namespace Domain.Entities;

public class Client
{
    public Guid Id { get; private set; }
    public string? Name { get; private set; }
    public string? Surname { get; private set; }
    public int Age { get; private set; }
    public string? Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    public bool Active { get; private set; }

    public static Client Create(string? name, string? surname, int age, string? email)
    {
        return new Client
        {
            Id = Guid.NewGuid(),
            Name = name,
            Surname = surname,
            Age = age,
            Email = email,
            CreatedAt = DateTime.UtcNow,
            Active = true
        };
    }

    public static Client Update(Client item, string? name, string? surname, int age)
    {
        item.Name = name;
        item.Surname = surname;
        item.Age = age;
        item.UpdatedAt = DateTime.UtcNow;

        return item;
    }

    public static Client UpdateAge(Client item, int age)
    {
        if(age < 18)
        {
            throw new Exception("User can't change it's own Age.");
        }

        item.Age = age;
        item.UpdatedAt = DateTime.UtcNow;

        return item;
    }   

    public static Client Delete(Client item)
    {
        item.DeletedAt = DateTime.UtcNow;
        item.Active = false;

        return item;
    }
}