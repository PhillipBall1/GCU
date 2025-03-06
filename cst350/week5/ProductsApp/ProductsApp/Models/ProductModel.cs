namespace ProductsApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ImageURL { get; set; }

        public ProductModel(int Id, string Name, decimal Price, string Description, DateTime CreatedAt, string ImageURL) 
        {
            this.Id = Id;
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
            this.CreatedAt = CreatedAt;
            this.ImageURL = ImageURL;
        }

        public ProductModel() { }

        public override bool Equals(object? obj)
        {
            return Equals(obj as ProductModel);
        }

        public bool Equals(ProductModel? other) 
        {
            return other != null && this.Id == other?.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();  
        }
    }
}
