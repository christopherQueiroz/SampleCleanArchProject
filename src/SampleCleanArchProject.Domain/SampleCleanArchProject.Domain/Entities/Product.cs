using SampleCleanArchProject.Domain.Validation;

namespace SampleCleanArchProject.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");

            DomainExceptionValidation.When(price < 0,
                "Invalid price value");

            DomainExceptionValidation.When(stock < 0,
              "Invalid stock value");

            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }

        public Product(string name, string description, decimal price, int stock, string image) =>
            ValidateDomain(name, description, price, stock, image);

        //public Product(int id, string name, string description, decimal price, int stock, string image)
        //{
        //    DomainExceptionValidation.When(id < 0, "Invalid Id value");
        //    Id = id;
        //    ValidateDomain(name, description, price, stock, image);
        //}

        private void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            this.CategoryId = categoryId;
        }
    }
}
