using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PrescriptionAPI.Dto;
using PrescriptionAPI.Models;
using PrescriptionAPI.Models.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrescriptionAPI.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class PrescriptionController : ControllerBase
    {

        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMapper _mapper;
        public PrescriptionController(IPrescriptionRepository prescriptionRepository, IMapper mapper)
        {
            _prescriptionRepository = prescriptionRepository;
            _mapper = mapper;
        }   
        // GET: api/<PrescrptionController>
        [HttpGet]
        public ActionResult<IEnumerable<PrescriptionReadDto>> Get()
        {
            var prescriptions = _prescriptionRepository.GetAll();

            var prescriptionDto = _mapper.Map<IEnumerable<PrescriptionReadDto>>(prescriptions);

            if(prescriptions == null)
            {
               return NotFound();
            }
            return Ok(prescriptionDto);

        }

        [HttpGet("{id}" , Name = "GetPrescriptionById")]
        public ActionResult<PrescriptionReadDto> GetPrescriptionById(int id)
        {
            var prescription = _prescriptionRepository.Get(id);
            if(prescription == null)
            {
                return NotFound(id);
            }
            return (_mapper.Map<PrescriptionReadDto>(prescription));
        }

        [HttpPost]
        public ActionResult<PrescriptionReadDto> CreatePrescription(
            PrescriptionCreateDto prescriptionCreateDto)
        {

            //Mapeamento de Persist para Data
            var prescriptionModel = _mapper.Map<Prescription>(prescriptionCreateDto);

            _prescriptionRepository.Create(prescriptionModel);
            _prescriptionRepository.SaveChanges();

            //Mappeamento do Prescription para o Dtod
            var prescriptionReadDto = _mapper.Map<PrescriptionReadDto>(prescriptionModel);

            return CreatedAtRoute(nameof(GetPrescriptionById),
                new { Id = prescriptionReadDto.Id }, prescriptionReadDto);
        }
        
    }
}
