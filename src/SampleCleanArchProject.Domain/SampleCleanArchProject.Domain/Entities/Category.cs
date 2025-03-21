using SampleCleanArchProject.Domain.Validation;

namespace SampleCleanArchProject.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }

        public Category(string name) => ValidateDomain(name);

        public void Update(string name) => ValidateDomain(name);

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            this.Name = name;
        }
    }
}