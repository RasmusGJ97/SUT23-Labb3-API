using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_Labb3_API.Models;

namespace SUT23_Labb3_API.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private ILabb3<Interest> _interest;

        public InterestController(ILabb3<Interest> iLabb3)
        {
            _interest = iLabb3;
        }

        [HttpGet("Get all interests")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _interest.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database . . .");
            }
        }

        [HttpGet("{id:int} Get interest by id:")]
        public async Task<ActionResult<Interest>> GetSingle(int id)
        {
            try
            {
                var result = await _interest.GetSpecific(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database . . .");
            }
        }

        [HttpPost(" Add interest")]
        public async Task<ActionResult<Interest>> AddInterest(Interest newInterest)
        {
            try
            {
                if (newInterest == null)
                {
                    return BadRequest();
                }
                var createdInterest = await _interest.Add(newInterest);
                return CreatedAtAction(nameof(GetSingle), new { id = createdInterest.InterestId }, createdInterest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create data in the Database . . .");
            }
        }
    }
}
