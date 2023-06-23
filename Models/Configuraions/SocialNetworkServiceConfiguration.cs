using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Net.Core.Api.EF.Core.Angular.Models.Configuraions
{
    public class SocialNetworkServiceConfiguration : IEntityTypeConfiguration<SocialNetworkService>
    {
        public void Configure(EntityTypeBuilder<SocialNetworkService> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
