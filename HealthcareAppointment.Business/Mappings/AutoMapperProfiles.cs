using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareAppointment.Models.Models.Domain;
using HealthcareAppointment.Models.Models.DTO;

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
        }
    }
}
