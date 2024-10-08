using AiTiman_API.Models;
using AiTiman_API.Services.DTO;
using AiTiman_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AiTiman_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescription _prescription;

        // Constructor injection of the IPrescription service
        public PrescriptionController(IPrescription prescription)
        {
            _prescription = prescription;
        }


        [HttpGet("All-Prescriptions")]
        public async Task<IActionResult> AllPrescriptions()
        {
            var prescriptions = await _prescription.fetchPrescriptions();
            return Ok(prescriptions);
        }


        [HttpGet("Fetch-Prescription")]
        public async Task<IActionResult> FetchPrescription(string id)
        {
            var prescription = await _prescription.fetchPrescription(id);
            return Ok(prescription);
        }

        [HttpPost("Create-New-Prescription")]
        public async Task<IActionResult> CreateNewPrescription(CreatePrescriptionDTO createPrescription)
        {
            var (isSuccess, message) = await _prescription.AddNewPrescription(createPrescription);

            if (!isSuccess)
                return BadRequest(message);

            return Ok(message);
        }

        [HttpPut("Update-Prescription")]
        public async Task<IActionResult> UpdatePrescription(string id, UpdatePrescriptionDTO updatePrescription)
        {
            var (isSuccess, message) = await _prescription.UpdatePrescription(id, updatePrescription);

            if (!isSuccess)
                return BadRequest(message);

            return Ok(message);
        }

        [HttpDelete("Delete-Prescription")]
        public async Task<IActionResult> DeletePrescription(string id)
        {
            var (isSuccess, message) = await _prescription.DeletePrescription(id);

            if (!isSuccess)
                return BadRequest(message);

            return Ok(message);
        }

    }

}


