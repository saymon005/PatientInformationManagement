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
    public class NCDController : Controller
    {
        private readonly INCDRepository _nCDRepository;
        private readonly IMapper _mapper;

        public NCDController(INCDRepository nCDRepository, IMapper mapper)
        {
            _nCDRepository = nCDRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NCD>))]
        public IActionResult GetNCDs()
        {
            var ncd = _mapper.Map<List<NCDDto>>(_nCDRepository.GetNCDs());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ncd);
        }

        [HttpGet("{ncdId}")]
        [ProducesResponseType(200, Type = typeof(NCD))]
        [ProducesResponseType(400)]
        public IActionResult GetNCD(int ncdId)
        {
            if (!_nCDRepository.NCDExist(ncdId))
            {
                return NotFound();
            }
            var ncd = _mapper.Map<NCDDto>(_nCDRepository.GetNCD(ncdId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ncd);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateNCD([FromBody] NCDDto ncdCreate)
        {
            if (ncdCreate == null)
                return BadRequest(ModelState);

            var disease = _nCDRepository.GetNCDs()
                .Where(n => n.NCDName.Trim().ToUpper() == ncdCreate.NCDName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (disease != null)
            {
                ModelState.AddModelError("", "NCD already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ncdMap = _mapper.Map<NCD>(ncdCreate);

            if (!_nCDRepository.CreateNCD(ncdMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{ncdId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateNCD(int ncdId, [FromBody] NCDDto updatedNCD)
        {
            if (updatedNCD == null)
                return BadRequest(ModelState);

            if (ncdId != updatedNCD.ID)
                return BadRequest(ModelState);

            if (!_nCDRepository.NCDExist(ncdId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var ncdMap = _mapper.Map<NCD>(updatedNCD);

            if (!_nCDRepository.UpdateNCD(ncdMap))
            {
                ModelState.AddModelError("", "Something went wrong updating NCD!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{ncdId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteNCD(int ncdId)
        {
            if (!_nCDRepository.NCDExist(ncdId))
            {
                return NotFound();
            }

            var ncdToDelete = _nCDRepository.GetNCD(ncdId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_nCDRepository.DeleteNCD(ncdToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting NCD");
            }

            return NoContent();
        }
    }
}
