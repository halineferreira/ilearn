using FluentValidation;
using FluentValidation.Results;

namespace ilearn_users_api.Domain.ValueObjects
{
    public class Subject : AbstractValidator<Subject>
    {
        public Subject(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public bool Validate()
        {
            ValidateName();
            ValidateDescription();

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome da disciplina não pode ser vazio.")
                .MaximumLength(100).WithMessage("Nome da disciplina pode ter no máximo 100 caracteres.");
        }

        private void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Descrição da disciplina não pode ser vazio.")
                .MaximumLength(1000).WithMessage("Descrição da disciplina pode ter no máximo 1000 caracteres.");
        }

    }
}
