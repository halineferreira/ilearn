using FluentValidation;
using FluentValidation.Results;
using ilearn_users_api.Data.Schemas;
using System.Net;

namespace ilearn_users_api.Domain.ValueObjects
{
    public class Address : AbstractValidator<Address>
    {
        public Address(string street, string number, string city, string state, string country, string zipCode)
        {
            Street = street;
            Number = number;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public ValidationResult ValidationResult { get; set; }

        public bool Validate()
        {
            ValidateStreet();
            ValidateCity();
            ValidateState();
            ValidateCountry();
            ValidateZipCode();

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void ValidateStreet()
        {
            RuleFor(c => c.Street)
                .NotEmpty().WithMessage("Logradouro não pode ser vazio.")
                .MaximumLength(100).WithMessage("Logradouro pode ter no máximo 100 caracteres.");
        }

        private void ValidateCity()
        {
            RuleFor(c => c.City)
                .NotEmpty().WithMessage("Cidade não pode ser vazio.")
                .MaximumLength(100).WithMessage("Cidade pode ter no máximo 100 caracteres.");
        }

        private void ValidateState()
        {
            RuleFor(c => c.State)
                .NotEmpty().WithMessage("Estado não pode ser vazio.")
                .MaximumLength(2).WithMessage("Estado pode ter no máximo 2 caracteres.");
        }
        
        private void ValidateCountry()
        {
            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage("País não pode ser vazio.")
                .MaximumLength(100).WithMessage("País pode ter no máximo 100 caracteres.");
        }

        private void ValidateZipCode()
        {
            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage("CEP não pode ser vazio.")
                .MaximumLength(8).WithMessage("CEP pode ter no máximo 8 caracteres.");
        }
    }
}
