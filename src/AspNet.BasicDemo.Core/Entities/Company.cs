namespace AspNet.BasicDemo.Core.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public string Website { get; set; }
    public virtual List<Customer> Customers { get; set; } = new();
}