namespace AppRevendedores.Dtos
{
    public class ProductUpdateDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }

    }
}
