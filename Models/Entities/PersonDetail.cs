namespace WebApp.Net.Core.Api.EF.Core.Angular.Models
{
    public class PersonDetail
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int PersonId { get; set; } //1 to 1 relationship by convention
    }
}
