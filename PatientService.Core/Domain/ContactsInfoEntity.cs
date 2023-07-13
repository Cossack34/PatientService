using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientService.Core.Domain
{
    public class ContactsInfoEntity : BaseEntity
    {
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool isAvaliable { get; set; }
        public virtual PatientEntity Patient { get; set; }
    }
}
