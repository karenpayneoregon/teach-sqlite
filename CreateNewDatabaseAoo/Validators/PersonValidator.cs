#nullable disable
using CreateNewDatabaseApp.DapperModels;
using CreateNewDatabaseApp.LanguageExtensions;
using FluentValidation;

namespace CreateNewDatabaseApp.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {

        Include(new FirstLastNameValidator());
        RuleFor(x => x.BirthDate).BirthDateRule();

    }
}