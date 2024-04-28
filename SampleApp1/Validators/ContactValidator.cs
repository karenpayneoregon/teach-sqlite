using FluentValidation;
using SampleApp1.Models;

namespace SampleApp1.Validators
{
    /// <summary>
    /// Basic example for a validator
    /// </summary>
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");

            RuleFor(x => x.ContactTitle)
                .NotEmpty()
                .WithMessage("Title is required");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required");

        }
    }

}