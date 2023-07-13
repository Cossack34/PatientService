using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientService.Core.Domain
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
    }
}
