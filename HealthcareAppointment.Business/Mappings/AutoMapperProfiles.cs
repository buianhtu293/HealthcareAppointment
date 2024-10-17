using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareAppointment.Models.Models.Domain;
using HealthcareAppointment.Models.Models.DTO;
using HealthcareAppointment.Models.Specifications;
using ShareKernel.Enum;

namespace HealthcareAppointment.Business.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        { 
            CreateMap<User, PatientDto>().ReverseMap();
            CreateMap<User, AddPatientRequestDto>().ReverseMap();
            CreateMap<User, UpdatePatientRequestDto>().ReverseMap();

            CreateMap<User, DoctorDto>().ReverseMap();
            CreateMap<User, AddDoctorRequestDto>().ReverseMap();
            CreateMap<User, UpdateDoctorRequestDto>().ReverseMap();

            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, AddAppointmentRequestDto>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentRequestDto>().ReverseMap();

            CreateMap<PaginationList<User>, PaginationList<DoctorDto>>().ReverseMap();
            CreateMap<PaginationList<User>, PaginationList<PatientDto>>().ReverseMap();
            CreateMap<PaginationList<Appointment>, PaginationList<AppointmentDto>>().ReverseMap();

            // Mapping from PatientDto to PatientStatusDto
            CreateMap<PatientDto, PatientStatusDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => ((Role)src.Role).ToString()));

            // Mapping from PaginationList<PatientDto> to PaginationList<PatientStatusDto>
            CreateMap<PaginationList<PatientDto>, PaginationList<PatientStatusDto>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items)); // Map the Items property
        }
    }
}
