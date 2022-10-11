using AutoMapper;
using PrescriptionAPI.Dto;
using PrescriptionAPI.Models;

namespace PrescriptionAPI.Profiles
{
    public class PrescriptionReadDtoProfile : Profile
    {
        public PrescriptionReadDtoProfile()
        {
            // Origem -> Destino
            CreateMap<Prescription, PrescriptionReadDto>();
        }
    }
}
