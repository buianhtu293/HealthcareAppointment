using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Models.Specifications
{
    public class PatientSpeParam : BaseSpeParam
    {
        private string? _search;
        public string? Search 
        { 
            get => _search; 
            set => _search = value; 
        }
    }
}
