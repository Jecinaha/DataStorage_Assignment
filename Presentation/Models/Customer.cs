
namespace Business.Models;

public class Customer
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public object FirstName { get; internal set; }
    public object LastName { get; internal set; }
}
