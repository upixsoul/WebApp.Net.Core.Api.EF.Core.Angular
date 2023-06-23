namespace WebApp.Net.Core.Api.EF.Core.Angular.Models.Dtos
{
    public class SocialEditNetworkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int PersonEditId { get; set; }
        public PersonEditDto PersonaEdit { get; set; }
        //TODO:
        /*public List<SocialNetworkService> SocialNetworkServices { get; set; }// Many to Many skip Navigation
        public List<SocialNetworkSocialNetworkDetail> SocialNetworkSocialNetworkDetails { get; set; }// Many to Many NON-skip Navigation
        */
    }
}
