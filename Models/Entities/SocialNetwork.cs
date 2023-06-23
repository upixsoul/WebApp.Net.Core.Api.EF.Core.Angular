using System.ComponentModel.DataAnnotations;
namespace WebApp.Net.Core.Api.EF.Core.Angular.Models
{
    public class SocialNetwork
    {
        public int Id { get; set; }
        //[MaxLength(100)]//DataAnnotations
        //[StringLength(maximumLength:100, MinimumLength = 10)]//DataAnnotations
        public string Name { get; set; }
        [Url]//DataAnnotations
        public string Url { get; set; }
        public int PersonId { get; set; }
        public Person Persona { get; set; }
        public List<SocialNetworkService> SocialNetworkServices { get; set; }// Many to Many skip Navigation
        public List<SocialNetworkSocialNetworkDetail> SocialNetworkSocialNetworkDetails { get; set; }// Many to Many NON-skip Navigation
    }
}
