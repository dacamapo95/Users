using Users.Domain.Primitives;

namespace Users.Domain.Entities;

public class User : AuditableEntity<Guid>
{
    public string UserName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string? SecondName { get; set; }

    public string LastName { get; set; } = default!;

    public string? SecondLastName { get; set; }

    public ICollection<Address> Addresses { get; } = [];

    private User()
    {
    }

    private User(
        string userName,
        string email,
        string password,
        string firstName,
        string? secondName, 
        string lastName,
        string? secondLastName)
    {
        UserName = userName;
        Email = email;
        Password = password;
        FirstName = firstName;
        SecondName = secondName;
        LastName = lastName;
        SecondLastName = secondLastName;
    }

    public static User Create(
        string userName,
        string email,
        string password, 
        string firstName,
        string? secondName,
        string lastName, 
        string? secondLastName) 
        => new(userName, 
            email,
            password,
            firstName,
            secondName,
            lastName,
            secondLastName);
}