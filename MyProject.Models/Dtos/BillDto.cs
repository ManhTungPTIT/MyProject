namespace MyProject.Models.Dtos;

public class BillDto : BaseDto
{
    public int Quantity { get; set; }
    public decimal TotalPPrice { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int EmployeeId { get; set; }
    
    public virtual EmployeeDto EmployeeDto { get; set; }
    public virtual CustomerDto CustomerDto { get; set; }
}