using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientService.Core.Domain
{
    public class CardsPatientEntity : BaseEntity
    {
        public string Insurance { get; set; }
        public string Snils { get; set; }
        public virtual PatientEntity Patient { get; set; }
    }
}
