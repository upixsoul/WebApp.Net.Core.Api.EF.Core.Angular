namespace WebApp.Net.Core.Api.EF.Core.Angular.Models
{
    public class SocialNetworkSocialNetworkDetail
    {
        public string InternalAnalisys { get; set; }//you can add more properties to the many to many intermediate table
        public int Importance { get; set; }//you can add more properties to the many to many intermediate table
        public int SocialNetworkId { get; set; }// Many to Many NON-skip Navigation
        public int SocialNetworkDetailId { get; set; }// Many to Many NON-skip Navigation
        public SocialNetwork SocialNetworks { get; set; }// Many to Many NON-skip Navigation
        public SocialNetworkDetail SocialNetworkDetails { get; set; }// Many to Many NON-skip Navigation
    }
}
