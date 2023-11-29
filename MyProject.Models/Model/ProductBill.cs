namespace MyProject.Models.Model;

public class ProductBill
{
    public int Id { get; set; }
    public DateTime CreateOn { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int BillId { get; set; }
    public Bill Bill { get; set; }
}