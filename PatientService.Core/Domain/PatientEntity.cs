using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientService.Core.Domain
{
    public class PatientEntity : BaseEntity
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
    }
}
