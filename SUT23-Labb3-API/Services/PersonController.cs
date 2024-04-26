using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_Labb3_API.Models;

namespace SUT23_Labb3_API.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private ILabb3<Person> _person;

        public PersonController(ILabb3<Person> pLabb3)
        {
            _person = pLabb3;
        }


        [HttpGet("Get all persons")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _person.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database . . .");
            }
        }

        [HttpGet("{personIid:int} Get Person by id:")]
        public async Task<ActionResult<Person>> GetSingle(int personId)
        {
            try
            {
                var result = await _person.GetSpecific(personId);
                if (result == null)
                {
                    return NotFound();
                }
                //var data = result.Select(p => new { p.PersonName }).FirstOrDefault();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database . . .");
            }
        }

        [HttpPost(" Add person")]
        public async Task<ActionResult<Person>> AddPerson(Person newPerson)
        {
            try
            {
                if (newPerson == null)
                {
                    return BadRequest();
                }
                var createdPerson = await _person.Add(newPerson);
                return CreatedAtAction(nameof(GetSingle), new { id = createdPerson.PersonId }, createdPerson);

                              
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create data in the Database . . .");
            }
        }
    }
}
