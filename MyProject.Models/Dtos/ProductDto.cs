namespace MyProject.Models.Dtos;

public class ProductDto : BaseDto
{
    public string Avatar { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
}