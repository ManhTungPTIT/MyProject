namespace MyProject.Models.Model;

public class Product
{
    public int Id { get; set; }
    public string Avatar { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public DateTime CreateOn { get; set; }
    
    public IList<ProductBill> ProductBills { get; set; }
}