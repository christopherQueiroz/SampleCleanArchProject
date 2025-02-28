using SampleCleanArchProject.Domain.Validation;

namespace SampleCleanArchProject.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string Name { get; private set; }

        public Category(string name) => ValidateDomain(name);
  

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id <= 0, "Invalid Id value.");
            this.Id = id;

            ValidateDomain(name);
        }

        public void Update(string name) => ValidateDomain(name);

        public ICollection<Product> Products { get; private set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            this.Name = name;
        }
    }
}