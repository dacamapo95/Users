using FluentValidation;

namespace Users.Application.Features.Users.AddAddress;
public sealed class AddAddressValidator : AbstractValidator<AddAddressCommand>
{
    public AddAddressValidator()
    {
        RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street is required.")
                .MaximumLength(100)
                .WithMessage("Street cannot exceed 100 characters.");

        RuleFor(x => x.CityId)
            .NotEmpty().WithMessage("CityId is required.");

        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("ZipCode is required.")
            .Length(6, 10).WithMessage("ZipCode must be between 6 and 10 characters.")
            .Must(BeNumeric).WithMessage("ZipCode must be numeric.")
            .When(x => !string.IsNullOrEmpty(x.ZipCode));
    }

    private bool BeNumeric(string value)
    {
        return int.TryParse(value, out _);
    }
}
