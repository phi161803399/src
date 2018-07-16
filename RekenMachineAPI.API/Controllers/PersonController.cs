using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;
using RekenMachineAPI.Domain;
using RekenMachineAPI.Service;

namespace RekenMachineAPI.API.Controllers
{
    [RoutePrefix("api/persons")]
    public class PersonController : BaseApiController
    {
        private readonly IService<Person> _personService;

        public PersonController(IService<Person> personService)
        {
            _personService = personService;
        }

        [HttpGet, Route]
        public async Task<IHttpActionResult> GetAll(string sort = null)
        {
            return Ok(await _personService.GetEf().ToListAsync());
        }

        [HttpGet, Route("{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var person = await _personService.GetAsyncEf(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }


        [HttpPost, Route]
        public async Task<IHttpActionResult> Post(Person person)
        {
            _personService.Add(person);
            await _personService.SaveChangesAsync();
            return Ok();
        }

        [HttpPut, Route("{id}")]
        public async Task<IHttpActionResult> Put(int id, Person person)
        {
            var personToUpdate = await _personService.GetAsyncEf(id);

            if (personToUpdate == null)
                return NotFound();

            personToUpdate.Name = person.Name;
            personToUpdate.Address = person.Address;
            await _personService.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var personToDelete = await _personService.GetAsyncEf(id);

            if (personToDelete == null)
                return NotFound();

            _personService.Delete(personToDelete);
            await _personService.SaveChangesAsync();

            return Ok();
        }
    }    
}