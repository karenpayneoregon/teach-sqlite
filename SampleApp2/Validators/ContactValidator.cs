using FluentValidation;
using SampleApp2.Models;


namespace SampleApp1.Validators
{
    /// <summary>
    /// Basic example for a validator
    /// </summary>
    public class ContactValidator : AbstractValidator<Contacts>
    {
        public ContactValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");

        }
    }

    public class ContactContainerValidator : AbstractValidator<ContactContainer>
    {
        public ContactContainerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("First name is required");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last name is required");
        }
    }
}