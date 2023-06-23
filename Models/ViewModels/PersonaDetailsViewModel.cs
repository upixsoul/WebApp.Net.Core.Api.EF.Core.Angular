using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace WebApp.Net.Core.Api.EF.Core.Angular.Models.ViewModels
{
    public class PersonaDetailsViewModel
    {
        [DisplayName("Persona Id")]
        public int PersonId { get; set; }
        [DisplayName("Nombre de la Persona")]
        public string Name { get; set; }
        [DisplayName("Edad de la Persona")]
        public int Age { get; set; }
        [DisplayName("Numero de Contacto")]
        public string Number { get; set; }
        [HiddenInput]
        public int? PersonDetailsId { get; set; }
        [DisplayName("Numero de Identificacion Fiscal")]
        public string IdentificationNumber { get; set; }
        [DisplayName("Fecha De Nacimiento")]
        public DateTime? DateOfBirth { get; set; }
    }
}
