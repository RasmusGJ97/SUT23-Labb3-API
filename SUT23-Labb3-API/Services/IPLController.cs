using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SUT23_Labb3_API.Models;

namespace SUT23_Labb3_API.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPLController : ControllerBase
    {
        private ILabb3<InterestPersonLink> _interestPersonLink;

        public IPLController(ILabb3<InterestPersonLink> iplLabb3)
        {
            _interestPersonLink = iplLabb3;
        }

        [HttpGet("Get all connections")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                //var interestPersonLinks = await _interestPersonLink.GetAll();

                //var projectedData = interestPersonLinks.Select(ipl => new { ipl.PersonId, ipl.InterestId, ipl.LinkId });

                //return Ok(projectedData);

                return Ok(await _interestPersonLink.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database . . .");
            }
        }

        [HttpGet("{id:int} Get Person by id:")]
        public async Task<ActionResult<InterestPersonLink>> GetSingle(int id)
        {
            try
            {
                var result = await _interestPersonLink.GetSpecific(id);
                if (result == null)
                {
                    return NotFound();
                }
                var data = result.Select(ipl => new { ipl.Persons}).FirstOrDefault();
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database . . .");
            }
        }

        [HttpPost("Connect interest and links to a person")]
        public async Task<ActionResult<InterestPersonLink>> Add(int personId, int interestId, int linkId)
        {
            try
            {
                var newIPL = new InterestPersonLink
                {
                    PersonId = personId,
                    InterestId = interestId,
                    LinkId = linkId
                };

                var createdIPL = await _interestPersonLink.Add(newIPL);
                return CreatedAtAction(nameof(GetSingle),
                    new { id = createdIPL.PersonId }, createdIPL);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to create data in the Database . . .");
            }
        }

        [HttpGet("Get all interests for a person")]
        public async Task<ActionResult<InterestPersonLink>> GetInterests(int personId)
        {
            try
            {
                var result = await _interestPersonLink.GetSpecific(personId);
                if (result == null)
                {
                    return NotFound();
                }
                var data = result.Select(ipl => new { ipl.Interests }).Distinct();
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database . . .");
            }
        }

        [HttpGet("Get all links for a person")]
        public async Task<ActionResult<InterestPersonLink>> GetLinks(int personId)
        {
            try
            {
                var result = await _interestPersonLink.GetSpecific(personId);
                if (result == null)
                {
                    return NotFound();
                }
                var data = result.Select(ipl => new { ipl.Links }).Distinct();
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error to retrive data from Database . . .");
            }
        }
    }
}
