namespace WebApp.Net.Core.Api.EF.Core.Angular.Models.Dtos
{
    public class PersonEditDetailDto
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int PersonEditId { get; set; }
    }
}
