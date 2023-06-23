namespace WebApp.Net.Core.Api.EF.Core.Angular.Models.Dtos
{
    public class PersonEditDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Number { get; set; }

        public PersonEditDetailDto? PersonEditDetails { get; set; }//1 to 1 relationship by convention
        //Todo://public List<SocialEditNetworkDto> SocialEditNetworks { get; set; }
    }
}
