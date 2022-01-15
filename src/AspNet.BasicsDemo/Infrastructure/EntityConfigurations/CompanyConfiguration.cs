namespace AspNet.BasicsDemo.Infrastructure.EntityConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(company => company.Id);
        builder.Property(company => company.Id)
            .ValueGeneratedOnAdd();

        builder.HasMany(company => company.Customers)
            .WithOne(customer => customer.Company)
            .HasForeignKey(customer => customer.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}