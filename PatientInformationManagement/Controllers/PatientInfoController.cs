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
    public class PatientInfoController : Controller
    {
        private readonly IPatientInfoRepository _patientInfoRepository;
        private readonly INCDRepository _nCDRepository;
        private readonly IAllergiesRepository _allergiesRepository;
        private readonly IMapper _mapper;

        public PatientInfoController(IPatientInfoRepository patientInfoRepository, INCDRepository nCDRepository, IAllergiesRepository allergiesRepository, IMapper mapper)
        {
            _patientInfoRepository = patientInfoRepository;
            _nCDRepository = nCDRepository;
            _allergiesRepository = allergiesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PatientInfo>))]
        public IActionResult GetPatientInfos()
        {
            var patientinfo = _mapper.Map<List<PatientInfoDto>>(_patientInfoRepository.GetPatientInfos());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(patientinfo);
        }

        [HttpGet("{patientInfoId}")]
        [ProducesResponseType(200, Type = typeof(PatientInfo))]
        [ProducesResponseType(400)]
        public IActionResult GetPatientInfo(int patientInfoId)
        {
            if (!_patientInfoRepository.PatientInfoExist(patientInfoId))
            {
                return NotFound();
            }
            var patientinfo = _mapper.Map<PatientInfoDto>(_patientInfoRepository.GetPatientInfo(patientInfoId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(patientinfo);
        }

        [HttpGet("patientsByNCD/{ncdId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PatientInfo>))]
        [ProducesResponseType(400)]
        public ActionResult GetPatientsByNCDId(int ncdId)
        {
            var ncds = _mapper.Map<List<PatientInfoDto>>(_patientInfoRepository.GetPatientsByNCDId(ncdId));
            if (!_patientInfoRepository.PatientInfoExist(ncdId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(ncds);
        }
        [HttpGet("ncdsByPatient/{patientId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<NCD>))]
        [ProducesResponseType(400)]
        public ActionResult GetNCDByPatientId(int patientId)
        {
            var patients = _mapper.Map<List<NCDDto>>(_patientInfoRepository.GetNCDsByPatientId(patientId));
            if (!_patientInfoRepository.PatientInfoExist(patientId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(patients);
        }

        [HttpGet("patientsByAllergies/{allergiesId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PatientInfo>))]
        [ProducesResponseType(400)]
        public ActionResult GetPatientsByAllergiesId(int allergiesId)
        {
            var patients = _mapper.Map<List<PatientInfoDto>>(_patientInfoRepository.GetPatientsByAllergiesId(allergiesId));
            if (!_patientInfoRepository.PatientInfoExist(allergiesId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(patients);
        }

        [HttpGet("allergiesByPatient/{patientId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Allergies>))]
        [ProducesResponseType(400)]
        public ActionResult GetAllergiesByPatientId(int patientId)
        {
            var allergies = _mapper.Map<List<AllergiesDto>>(_patientInfoRepository.GetAllergiesByPatientId(patientId));
            if (!_patientInfoRepository.PatientInfoExist(patientId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(allergies);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePatientInfo([FromQuery] int ncdId, [FromQuery] int allergyId, [FromBody] PatientInfoDto patientCreate)
        {
            if (patientCreate == null)
                return BadRequest(ModelState);

            var patient = _patientInfoRepository.GetPatientInfos()
                .Where(p => p.PatientName.Trim().ToUpper() == patientCreate.PatientName.TrimEnd().ToUpper())
                .FirstOrDefault();

            /*if (patient != null)
            {
                ModelState.AddModelError("", "Patient already exists");
                return StatusCode(422, ModelState);
            }*/

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patientMap = _mapper.Map<PatientInfo>(patientCreate);

            //patientMap.NCD_Details = _nCDRepository.GetNCD(ncdId);
            //patientMap.Allergies_Details = _allergiesRepository.GetAllergy(allergyId);

            if (!_patientInfoRepository.CreatePatientInfo(ncdId, allergyId, patientMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{patientInfoId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePatientInfo(int ncdId, int allergyId, int patientInfoId, [FromBody] PatientInfoDto updatedPatientInfo)
        {
            if (updatedPatientInfo == null)
                return BadRequest(ModelState);

            if (patientInfoId != updatedPatientInfo.ID)
                return BadRequest(ModelState);

            if (!_patientInfoRepository.PatientInfoExist(patientInfoId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var patientInfoMap = _mapper.Map<PatientInfo>(updatedPatientInfo);

            if (!_patientInfoRepository.UpdatePatientInfo(ncdId, allergyId, patientInfoMap))
            {
                ModelState.AddModelError("", "Something went wrong updating Patient Info!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{patientId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePatientInfo(int patientId)
        {
            if (!_patientInfoRepository.PatientInfoExist(patientId))
            {
                return NotFound();
            }

            var patientToDelete = _patientInfoRepository.GetPatientInfo(patientId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_patientInfoRepository.DeletePatientInfo(patientToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting Patient");
            }

            return NoContent();
        }
    }
}
