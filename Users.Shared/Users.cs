using System.ComponentModel.DataAnnotations;

namespace Users.Shared;

public record CreateUserRequest(
        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(25, ErrorMessage = "Username cannot exceed 25 characters.")]
        string UserName,

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        string Email,

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [MaxLength(50, ErrorMessage = "Password cannot exceed 50 characters.")]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*[!@#$%^&*(),.?\":{}|<>]).*$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one special character.")]
        string Password,

        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        string FirstName,

        [MaxLength(50, ErrorMessage = "Second name cannot exceed 50 characters.")]
        string? SecondName,

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        string LastName,

        [MaxLength(50, ErrorMessage = "Second last name cannot exceed 50 characters.")]
        string? SecondLastName
    ) : BaseUserRecord(
        UserName,
        Email,
        FirstName,
        SecondName,
        LastName,
        SecondLastName);


public record UpdateUserRequest(
    Guid Id,
    string Password,
    string UserName,
    string Email,
    string FirstName,
    string? SecondName,
    string LastName,
    string? SecondLastName
) : BaseUserRecord(
    UserName,
    Email,
    FirstName,
    SecondName,
    LastName,
    SecondLastName);

public abstract record BaseUserRecord(
    string UserName,
    string Email,
    string FirstName,
    string? SecondName,
    string LastName,
    string? SecondLastName
);

public record UserDetailResponse(
    Guid Id,
    string UserName,
    string Email,
    string FirstName,
    string? SecondName,
    string LastName,
    string? SecondLastName,
    string Password
) : BaseUserRecord(
    UserName,
    Email,
    FirstName,
    SecondName,
    LastName,
    SecondLastName);

public record UserResponse(
    Guid Id,
    string UserName,
    string Email,
    string FirstName,
    string LastName
);

public record AddressRequest(
     string Street,
     Guid CityId,
     string? ZipCode
);

public record AddressResponse(
    Guid Id,
    string Street,
    string City,
    string ZipCode
);
