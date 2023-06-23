using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Net.Core.Api.EF.Core.Angular.Models.Configuraions
{
    public class SocialNetworkSocialNetworkDetailConfiguration : IEntityTypeConfiguration<SocialNetworkSocialNetworkDetail>
    {
        public void Configure(EntityTypeBuilder<SocialNetworkSocialNetworkDetail> builder)
        {
            builder.HasKey(p =>
            new { p.SocialNetworkId, p.SocialNetworkDetailId });//composite key for Many to Many NON-skip Navigation
        }
    }
}
