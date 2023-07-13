using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientService.Core.Abstractions.Repositories;
using PatientService.Core.Domain;

namespace PatientService.Controllers
{
    /// <summary>
    /// Пациенты
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly IRepository<PatientEntity> _patientRepository;

        public PatientsController(IRepository<PatientEntity> patientRepository)
        {
            _patientRepository = patientRepository;

        }
    }
}
