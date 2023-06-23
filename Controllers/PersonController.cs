using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Net.Core.Api.EF.Core.Angular.Models;
using WebApp.Net.Core.Api.EF.Core.Angular.Models.Dtos;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace WebApp.Net.Core.Api.EF.Core.Angular.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("api/Person")]
    public class PersonController : ControllerBase
    {

        private readonly AppDbContext1 _dbContext;
        private readonly IMapper mapper;

        public PersonController(AppDbContext1 dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        //endpoint
        /*[HttpGet(Name = "GetPerson")]
        public async Task<IEnumerable<Person>> Get()
        {
            var personas = await _dbContext.Personas.ToListAsync();
            return personas;
        }*/

        [HttpGet(template: "GetPerson", Name = "GetPerson")]
        public async Task<IEnumerable<PersonDto>> Get()
        {
            var personas = await _dbContext.Personas
                .ProjectTo<PersonDto>(mapper.ConfigurationProvider).ToListAsync();
            return personas;
        }

        [HttpGet(template: "GetPerson2/{id}", Name = "GetPerson2")]
        public async Task<IEnumerable<PersonDto>> GetPerson2(int id)
        {
            return await _dbContext.Personas.Select(x => new PersonDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }

        [HttpGet(template: "GetPersonDeferred", Name = "GetPersonDeferred")]
        public async Task<IEnumerable<PersonDto>> GetPersonDeferred([FromQuery] PersonFilterDto personFilterDto)
        {
            var personQuerable = _dbContext.Personas.AsQueryable();
            if (personFilterDto == null)
            {
                return null;
            }

            if (personFilterDto.Name is not null &&
                !string.IsNullOrEmpty(personFilterDto.Name))
            {
                personQuerable = personQuerable.Where(p => p.Name.Contains(personFilterDto.Name));
            }

            if (personFilterDto.Number is not null &&
                !string.IsNullOrEmpty(personFilterDto.Number))
            {
                personQuerable = personQuerable.Where(p => p.Number.Contains(personFilterDto.Number));
            }

            if (personFilterDto.Age.HasValue && personFilterDto.Age > 0)
            {
                personQuerable = personQuerable.Where(p => p.Age.Equals(personFilterDto.Age));
            }

            var persons = await personQuerable.ToListAsync();

            return mapper.Map<IEnumerable<PersonDto>>(persons);
        }

        [HttpPost(template: "Edit", Name = "Edit")]
        public async Task<ActionResult> Edit(PersonEditDto editDto)
        {
            bool exists = _dbContext.Personas
            .Any(p => p.Id == editDto.Id);

            if (!exists)
            {
                return NotFound();
            }
            var person = mapper.Map<Person>(editDto);
            _dbContext.Entry(person).State = EntityState.Modified;
            _dbContext.Entry(person.PersonDetails).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}