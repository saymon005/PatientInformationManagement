using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatientInformationManagement.Dto;
using PatientInformationManagement.Interfaces;
using PatientInformationManagement.Models;
using PatientInformationManagement.Repository;

namespace PatientInformationManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AllergiesController : Controller
    {
        private readonly IAllergiesRepository _allergiesRepository;
        private readonly IMapper _mapper;

        public AllergiesController(IAllergiesRepository allergiesRepository, IMapper mapper)
        {
            _allergiesRepository = allergiesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Allergies>))]
        public IActionResult GetAllergies()
        {
            var allergies = _mapper.Map<List<AllergiesDto>>(_allergiesRepository.GetAllergies());

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(allergies);
        }

        [HttpGet("{allergyId}")]
        [ProducesResponseType(200, Type = typeof(Allergies))]
        [ProducesResponseType(400)]
        public IActionResult GetAllergy(int allergyId)
        {
            if(!_allergiesRepository.AllergiesExist(allergyId))
            {
                return NotFound();
            }
            var allergy = _mapper.Map<AllergiesDto>(_allergiesRepository.GetAllergy(allergyId));
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(allergy);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAllergies([FromBody] AllergiesDto allergiesCreate)
        {
            if (allergiesCreate == null)
                return BadRequest(ModelState);

            var disease = _allergiesRepository.GetAllergies()
                .Where(a => a.AllergyName.Trim().ToUpper() == allergiesCreate.AllergyName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (disease != null)
            {
                ModelState.AddModelError("", "Allergy already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var allergiesMap = _mapper.Map<Allergies>(allergiesCreate);

            if (!_allergiesRepository.CreateAllergies(allergiesMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{allergiesId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAllergies(int allergiesId, [FromBody] AllergiesDto updateAllergy)
        {
            if (updateAllergy == null)
                return BadRequest(ModelState);

            if (allergiesId != updateAllergy.ID)
                return BadRequest(ModelState);

            if (!_allergiesRepository.AllergiesExist(allergiesId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var allergiesMap = _mapper.Map<Allergies>(updateAllergy);

            if (!_allergiesRepository.UpdateAllergies(allergiesMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Allergy!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{allergiesId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAllergies(int allergiesId)
        {
            if (!_allergiesRepository.AllergiesExist(allergiesId))
            {
                return NotFound();
            }

            var allergyToDelete = _allergiesRepository.GetAllergy(allergiesId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_allergiesRepository.DeleteAllergies(allergyToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Allergy");
            }

            return NoContent();
        }

    }
}
