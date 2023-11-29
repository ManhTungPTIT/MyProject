namespace MyProject.Models.Model;

public class Bill
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPPrice { get; set; }
    public DateTime CreateOn { get; set; }
    
    public int CustomerId { get; set; }
    public Customers Customers { get; set; }
    
    public int EmployeeId { get; set; }
    public Employees Employees { get; set; }
    
    public virtual Product Product { get; set; }
    public IList<ProductBill> ProductBills { get; set; }
}