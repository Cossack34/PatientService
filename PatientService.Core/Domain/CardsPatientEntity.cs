using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientService.Core.Domain
{
    public class CardsPatientEntity : BaseEntity
    {
        public string Insurance { get; set; }
        public string Snils { get; set; }
        public virtual PatientEntity Patient { get; set; }
    }
}
