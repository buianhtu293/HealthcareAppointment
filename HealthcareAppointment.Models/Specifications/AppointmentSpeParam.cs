using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareKernel.Enum;

namespace HealthcareAppointment.Models.Specifications
{
    public class AppointmentSpeParam : BaseSpeParam
    {
        public DateOnly FromDate {  get; set; } = DateOnly.MinValue;
        public DateOnly ToDate { get; set;} = DateOnly.MaxValue;
        public List<Status> Statuses {  get; set; } = new List<Status>() { Status.Scheduled, Status.Completed, Status.Cancelled }; 
    }
}
