using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Net.Core.Api.EF.Core.Angular.Models.Configuraions
{
    public class PersonDetailConfiguration : IEntityTypeConfiguration<PersonDetail>
    {
        public void Configure(EntityTypeBuilder<PersonDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdentificationNumber).IsRequired();
        }
    }
}
