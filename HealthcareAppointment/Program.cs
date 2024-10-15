
using HealthcareAppointment.Business.Mappings;
using HealthcareAppointment.Business.Services.AppointmentService;
using HealthcareAppointment.Business.Services.DoctorService;
using HealthcareAppointment.Business.Services.PatientService;
using HealthcareAppointment.Data.Data;
using HealthcareAppointment.Data.Repositories;
using HealthcareAppointment.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HealthcareDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("HealthcareConnectionString")));

            builder.Services.AddTransient<IPatientRepository, PatientRepository>();
            builder.Services.AddTransient<IPatientService, PatientService>();

            builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
            builder.Services.AddTransient<IDoctorService, DoctorService>();

            builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            builder.Services.AddTransient<IAppointmentService, AppointmentService>();

            builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
