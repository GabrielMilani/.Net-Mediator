using Market.Domain.Validation;
using System.Text.Json.Serialization;

namespace Market.Domain.Entities
{
    public sealed class Member : Entity
    {
        public Member() { }
        public Member(string firstName, string lastName, string gender, string email, bool? isActive)
        {
            ValidateDomain(firstName, lastName, gender, email, isActive);
        }

        [JsonConstructor]
        public Member(int id, string firstName, string lastName, string gender, string email, bool? isActive)
        {
            DomainValidation.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(firstName, lastName, gender, email, isActive);
        }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Gender { get; private set; }
        public string? Email { get; private set; }
        public bool? IsActive { get; private set; }

        private void ValidateDomain(string firstName, string lastName, string gender, string email, bool? isActive)
        {
            DomainValidation.When(string.IsNullOrEmpty(firstName), "Invalid name. FirstName is required");
            DomainValidation.When(firstName.Length < 3, "Invalid name, to short, minimum 3 characters");
            DomainValidation.When(string.IsNullOrEmpty(lastName), "Invalid lastname. LastName is required");
            DomainValidation.When(lastName.Length < 3, "Invalid lastname, to short, minimum 3 characters");
            DomainValidation.When(email?.Length > 250, "Invalid email, to long, maximum 250 characters");
            DomainValidation.When(email?.Length < 6, "Invalid email, to short, minimum 6 characters");
            DomainValidation.When(string.IsNullOrEmpty(gender), "Invalid gender. Gender is required");
            DomainValidation.When(!isActive.HasValue, "Must define activity");

            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            IsActive = isActive;
        }

        public void Update(string firstName, string lastName, string gender, string email, bool? isActive)
        {
            ValidateDomain(firstName, lastName, gender, email, isActive);
        }
    }
}
