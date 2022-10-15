using FluentValidation;
using FluentValidation.Results;
using ilearn_users_api.Domain.ValueObjects;
using System.Xml.Serialization;

namespace ilearn_users_api.Domain.Entities
{
    public class User : AbstractValidator<User>
    {
        public User( string name, string email, string phone, string password)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
        }
        public User(string id, string name, string email, string phone, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Password = password;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public string Password { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public void AttributeAddress(Address address)
        {
            Address = address;
        }
        public virtual bool Validate()
        {
            ValidateName();
            ValidateEmail();

            ValidationResult = Validate(this);

            ValidateAddress();
            return ValidationResult.IsValid;

        }

        private void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome não pode ser vazio.")
                .MaximumLength(100).WithMessage("Nome pode ter no máximo 100 caracteres.");
        }
        private void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email não pode ser vazio.")
                .MaximumLength(100).WithMessage("Email pode ter no máximo 100 caracteres.");
        }

        private void ValidateAddress()
        {
            if (Address.Validate())
                return;

            foreach (var error in Address.ValidationResult.Errors)
                ValidationResult.Errors.Add(error);
        }
    }
}
