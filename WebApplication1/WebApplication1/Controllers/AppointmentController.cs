using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet("{id}/appointments")]
    public async Task<IActionResult> GetAppointments(int id)
    {
        
        var appointment = await _appointmentService.GetAppointment(id);
        
        if (appointment == null)
            return NotFound();
        
        return Ok(appointment);
    }

    [HttpPost("/api/appointments")]
    public async Task<IActionResult> AddAppointment(AppointmentDTO appointment)
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        
        
    }
}