using WebApplication1.Models;

namespace WebApplication1.Services;

public interface IAppointmentService
{
    Task<AppointmentDTO> GetAppointment(int appointmentId);
    Task<AppointmentDTO> AddAppointment(AppointmentDTO appointment);
}