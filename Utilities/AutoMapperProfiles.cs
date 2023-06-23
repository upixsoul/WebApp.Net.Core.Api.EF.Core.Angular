using AutoMapper;
using WebApp.Net.Core.Api.EF.Core.Angular.Models;
using WebApp.Net.Core.Api.EF.Core.Angular.Models.Dtos;
using WebApp.Net.Core.Api.EF.Core.Angular.Models.ViewModels;

namespace WebApp.Net.Core.Api.EF.Core.Angular.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
                      //From  To
            CreateMap<Person,PersonDto>().ReverseMap();

            CreateMap<SocialEditNetworkDto, SocialNetwork>().ReverseMap();

            CreateMap<PersonEditDetailDto,PersonDetail>().ReverseMap();

            CreateMap<Person, PersonEditDto>()
                //.ForMember(dto => dto.PersonsEditDetails,
                //ent => ent.MapFrom(p => p.PersonaDetails));
                /*.ForMember(dto => dto.SocialEditNetworks,
                ent => ent.MapFrom(p => p.SocialNertWorks));*/
                .ForMember(dto => dto.Id, ent => ent.MapFrom(p => p.Id))
                .ForMember(dto => dto.PersonEditDetails, ent => ent.MapFrom(p => p.PersonDetails))
                .ForMember(dto => dto.Age, ent => ent.MapFrom(p => p.Age))
                .ForMember(dto => dto.Number, ent => ent.MapFrom(p => p.Number))
                .ForMember(dto => dto.Name, ent => ent.MapFrom(p => p.Name))
                .ReverseMap();

            CreateMap<Person, PersonaDetailsViewModel>()
                .ForMember(vm => vm.PersonId, ent => ent.MapFrom(p => p.Id))
                .ForMember(vm => vm.PersonDetailsId, ent => ent.MapFrom(p => p.PersonDetails.Id))
                .ForMember(vm => vm.PersonId, ent => ent.MapFrom(p => p.PersonDetails.PersonId))
                .ForMember(vm => vm.DateOfBirth, ent => ent.MapFrom(p => p.PersonDetails.DateOfBirth))
                .ForMember(vm => vm.IdentificationNumber, ent => ent.MapFrom(p => p.PersonDetails.IdentificationNumber))
                //TODO: //.ForMember(vm => vm.socialNetwork, ent => ent.MapFrom(p => p.SocialNertWorks))
                .ReverseMap();

            //CreateMap<PersonaDetailsViewModel, Person>()
                //.ForPath(ent => ent.PersonaDetails.DateOfBirth, vm => vm.MapFrom(p => p.DateOfBirth))
                //.ForPath(ent => ent.PersonaDetails.IdentificationNumber, vm => vm.MapFrom(p => p.IdentificationNumber))
                //TODO: //.ForMember(vm => vm.socialNetwork, ent => ent.MapFrom(p => p.SocialNertWorks))
                ;
        }
    }
}
