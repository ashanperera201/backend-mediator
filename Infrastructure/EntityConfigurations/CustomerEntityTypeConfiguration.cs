#region References
using Domain.Aggregates.AirportAggregate;
using Domain.Aggregates.CustomerAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
#endregion

#region Namespace
namespace Infrastructure.EntityConfigurations
{
    public class CustomerEntityTypeConfiguration : BaseEntityTypeConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);

            builder.Property("FirstName")
                .IsRequired();  
            
            builder.Property("LastName")
                .IsRequired();

            builder.Property("DateOfBirth").IsRequired();

        }
    }
}
#endregion