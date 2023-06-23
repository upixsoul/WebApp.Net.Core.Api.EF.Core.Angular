using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Net.Core.Api.EF.Core.Angular.Models
{
    //[Table(name:"Personas", Schema ="entities")]
    public class Person //This Entiy represents a table from our database
    {
        public int Id { get; set; }
        //[Column(name:"PersonaName")]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Number { get; set; }
        //Navigation Property
        public PersonDetail PersonDetails { get; set; }//1 to 1 relationship by convention
        public List<SocialNetwork> SocialNertWorks { get; set; }//1 to many relationship by convention
    }
}
