namespace WebApp.Net.Core.Api.EF.Core.Angular.Models
{
    public class SocialNetworkService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<SocialNetwork> SocialNetworks { get; set; }// Many to Many skip Navigation
    }
}
