namespace AspNet.BasicDemo.Core.Entities;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; }
}