using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SUT23_Labb3_API.Models;

namespace SUT23_Labb3_API.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private ILabb3<Link> _link;

        public LinkController(ILabb3<Link> lLabb3)
        {
            _link = lLabb3;
        }

        [HttpGet("Get all Links")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _link.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database . . .");
            }
        }

        [HttpGet("{id:int} Get link by id:")]
        public async Task<ActionResult<Link>> GetSingle(int id)
        {
            try
            {
                var result = await _link.GetSpecific(id);
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

        [HttpPost(" Add link")]
        public async Task<ActionResult<Link>> AddInterest(Link newLink)
        {
            try
            {
                if (newLink == null)
                {
                    return BadRequest();
                }
                var createdLink = await _link.Add(newLink);
                return CreatedAtAction(nameof(GetSingle), new { id = createdLink.LinkId }, createdLink);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create data in the Database . . .");
            }
        }
    }
}
