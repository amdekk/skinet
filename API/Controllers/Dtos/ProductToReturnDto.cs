namespace API.Controllers.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Decription { get; set; }     
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public string ProductType { get; set; }
        
        public string ProductBrand { get; set; }
        
    }
}