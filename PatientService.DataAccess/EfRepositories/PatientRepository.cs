using PatientService.Core.Domain;
using PatientService.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientService.DataAccess.EfRepositories
{
    public class PatientRepository : EfRepository<PatientEntity>
    {
        public PatientRepository(DataContext context) : base(context)
        {

        }
    }
}
