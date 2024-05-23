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
    public class EpilepsyController : Controller
    {
        private readonly IEpilepsyRepository _epilepsyRepository;
        private readonly IMapper _mapper;

        public EpilepsyController(IEpilepsyRepository epilepsyRepository, IMapper mapper)
        {
            _epilepsyRepository = epilepsyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Epilepsy>))]
        public IActionResult GetEpilepsies()
        {
            var epilepsy = _mapper.Map<List<EpilepsyDto>>(_epilepsyRepository.GetEpilepsies());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(epilepsy);
        }

        [HttpGet("{epilepsyId}")]
        [ProducesResponseType(200, Type = typeof(Epilepsy))]
        [ProducesResponseType(400)]
        public IActionResult GetEpilepsy(int epilepsyId)
        {
            if (!_epilepsyRepository.EpilepsyExists(epilepsyId))
            {
                return NotFound();
            }
            var epilepsy = _mapper.Map<EpilepsyDto>(_epilepsyRepository.GetEpilepsy(epilepsyId));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(epilepsy);
        }
    }
}
