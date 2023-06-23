namespace WebApp.Net.Core.Api.EF.Core.Angular.Models
{
    public class SocialNetworkDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SocialNetworkSocialNetworkDetail> SocialNetworkSocialNetworkDetails { get; set; }// Many to Many NON-skip Navigation
    }
}
