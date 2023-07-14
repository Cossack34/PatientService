using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientService.Core.Abstractions.Repositories;
using PatientService.Core.Domain;
using PatientService.Models;

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

        /// <summary>
        /// Получить данные всех пациентов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<PatientShortResponse>> GetPatientsAsync()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Получить данные пациента по id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientResponse>> GetPatientAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Создать нового пациента
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePatientAsync(CreateOrEditPatientRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Изменить данные пациента
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditPatientAsync(Guid id, CreateOrEditPatientRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удалить пациента по id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);

            if (patient == null)
                return NotFound();


            await _patientRepository.DeleteAsync(patient);

            return Ok();
        }
    }
}
