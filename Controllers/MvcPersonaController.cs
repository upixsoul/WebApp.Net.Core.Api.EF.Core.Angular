using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Net.Core.Api.EF.Core.Angular.Models;
using WebApp.Net.Core.Api.EF.Core.Angular.Models.Dtos;
using WebApp.Net.Core.Api.EF.Core.Angular.Models.ViewModels;

namespace WebApp.Net.Core.Api.EF.Core.Angular.Controllers
{
    //http://localhost:5023/MvcPersona/Index
    public class MvcPersonaController : Controller
    {
        AppDbContext1 _dbContext;
        private readonly IMapper mapper;

        public MvcPersonaController(AppDbContext1 dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        // GET: MvcPersonaController
        public ActionResult Index()
        {
            List<Person> personas = _dbContext.Personas.ToList();
            return View(personas.Select(x => new PersonDto()
            {
                Name = x.Name,
                Id = x.Id
            }));
        }

        // GET: MvcPersonaController/Details/5
        public async Task<ActionResult> DetailsAsync(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            PersonaDetailsViewModel? persona = await _dbContext.Personas.Include(x => x.PersonDetails)
                .Where(p => p.Id == id).Select(x => new PersonaDetailsViewModel()
                {
                    PersonId = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                    DateOfBirth = x.PersonDetails.DateOfBirth,
                    PersonDetailsId = x.PersonDetails.Id,
                    IdentificationNumber = x.PersonDetails.IdentificationNumber,
                    Number = x.Number
                })
                .FirstOrDefaultAsync();

            if (persona is null)
            {
                return NotFound();
            }
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post: MvcPersonaController/Edit/5
        public async Task<ActionResult> EditAsync(int? id,
            [Bind("PersonId,Name,Age,Number,PersonDetailsId,IdentificationNumber,DateOfBirth")]
        PersonaDetailsViewModel personaVmodel)
        {
            if(ModelState.IsValid)
            {
                bool exists = _dbContext.Personas
                .Any(p => p.Id == id);

                if (!exists)
                {
                    return NotFound();
                }
                var person = mapper.Map<Person>(personaVmodel);
                _dbContext.Entry(person).State = EntityState.Modified;
                _dbContext.Entry(person.PersonDetails).State = EntityState.Modified;
                //_dbContext.Add(mappedPerson);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "MvcPersona");
            }
  
            return View(personaVmodel);
        }

        // GET: MvcPersonaController/Edit/5
        public async Task<ActionResult> EditAsync(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var personaInDb = await _dbContext.Personas.Include(x => x.PersonDetails)
                .Where(p => p.Id == id)
                .Select(x => new PersonaDetailsViewModel()
                {
                    PersonId = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                    PersonDetailsId = x.PersonDetails.Id,
                    DateOfBirth = x.PersonDetails.DateOfBirth,
                    IdentificationNumber = x.PersonDetails.IdentificationNumber,
                    Number = x.Number
                })
                .FirstOrDefaultAsync();

            if (personaInDb is null)
            {
                return NotFound();
            }

            var mappedPerson = mapper.Map<PersonaDetailsViewModel>(personaInDb);

            return View(mappedPerson);
        }

        // GET: MvcPersonaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MvcPersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        // GET: MvcPersonaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MvcPersonaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
