#nullable disable
using CreateNewDatabaseAoo.DapperModels;
using CreateNewDatabaseAoo.LanguageExtensions;
using FluentValidation;

namespace CreateNewDatabaseAoo.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {

        Include(new FirstLastNameValidator());
        RuleFor(x => x.BirthDate).BirthDateRule();

    }
}