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
    public class DiseaseInfoController : Controller
    {
        private readonly IDiseaseInfoRepository _diseaseInfoRepository;
        private readonly IMapper _mapper;

        public DiseaseInfoController(IDiseaseInfoRepository diseaseInfoRepository, IMapper mapper)
        {
            _diseaseInfoRepository = diseaseInfoRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<DiseaseInfo>))]
        public IActionResult GetDiseaseInfos()
        {
            var diseaseinfo = _mapper.Map<List<DiseaseInfoDto>>(_diseaseInfoRepository.GetDiseaseInfos());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(diseaseinfo);
        }

        [HttpGet("{diseaseId}")]
        [ProducesResponseType(200, Type = typeof(DiseaseInfo))]
        [ProducesResponseType(400)]
        public IActionResult GetDiseaseInfo(int diseaseId)
        {
            if (!_diseaseInfoRepository.DiseaseInfoExist(diseaseId))
            {
                return NotFound();
            }
            var diseaseinfo = _mapper.Map<DiseaseInfoDto>(_diseaseInfoRepository.GetDiseaseInfo(diseaseId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(diseaseinfo);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDiseaseInfo([FromBody] DiseaseInfoDto diseaseCreate)
        {
            if (diseaseCreate == null)
                return BadRequest(ModelState);

            var disease = _diseaseInfoRepository.GetDiseaseInfos()
                .Where(d => d.DiseaseName.Trim().ToUpper() == diseaseCreate.DiseaseName.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (disease != null)
            {
                ModelState.AddModelError("", "Disease already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var diseaseMap = _mapper.Map<DiseaseInfo>(diseaseCreate);

            if (!_diseaseInfoRepository.CreateDiseaseInfo(diseaseMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{diseaseInfoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDiseaseInfo(int diseaseInfoId, [FromBody] DiseaseInfoDto updatedAllergy)
        {
            if (updatedAllergy == null)
                return BadRequest(ModelState);

            if (diseaseInfoId != updatedAllergy.ID)
                return BadRequest(ModelState);

            if (!_diseaseInfoRepository.DiseaseInfoExist(diseaseInfoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var diseaseInfoMap = _mapper.Map<DiseaseInfo>(updatedAllergy);

            if (!_diseaseInfoRepository.UpdateDiseaseInfo(diseaseInfoMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Disease!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{diseaseId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDiseaseInfo(int diseaseId)
        {
            if (!_diseaseInfoRepository.DiseaseInfoExist(diseaseId))
            {
                return NotFound();
            }

            var diseaseToDelete = _diseaseInfoRepository.GetDiseaseInfo(diseaseId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_diseaseInfoRepository.DeleteDiseaseInfo(diseaseToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Disease");
            }

            return NoContent();
        }
    }
}
