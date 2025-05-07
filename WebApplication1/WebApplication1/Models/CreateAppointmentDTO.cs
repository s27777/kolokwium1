namespace WebApplication1.Models;

public class CreateAppointmentDTO
{
    public string AppointmentId { get; set; }
    public string PatientId { get; set; }
    public string DoctorId { get; set; }
    public DateTime Date { get; set; }
    
    
}