using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class AppointmentService : IAppointmentService
{
    private readonly string _connectionString = "Data Source=db-mssql;Initial Catalog=s27777;Integrated Security=True;Trust Server Certificate=True;";

    public async Task<AppointmentDTO> GetAppointment(int appointmentId)
    {
        string commmand = "SELECT * FROM Appointments JOIN Doctor ON Doctor.doctor_id = Appointments.doctor_id JOIN Patient ON Patient.patient_id = Appointments.Patient_patient_id WHERE Appointments.id = @appointmentId";
        
        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand(commmand, conn))
        {
            cmd.Parameters.AddWithValue("@id", appointmentId);
            await conn.OpenAsync();

            using (var result = await cmd.ExecuteReaderAsync())
            {
                if (await result.ReadAsync())
                {
                    return new AppointmentDTO()
                    {
                        AppointmentId = result.GetInt32(0),
                        PatientId = result.GetInt32(1),
                        DoctorId = result.GetInt32(2),
                        Date = result.GetDateTime(3)
                    };
                }
            }
        }
        return null;
    }

    public async Task<AppointmentDTO> AddAppointment(AppointmentDTO appointment)
    {
        string command = @"INSERT INTO Appointment(appointment_id, patient_id, doctor_id, date) VALUES(@appointmentId, @patientId, @doctorId, @date)";
        
        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand(command, conn))
        {
            cmd.Parameters.AddWithValue("@appointmentId", appointment.AppointmentId);
            cmd.Parameters.AddWithValue("@patientId", appointment.PatientId);
            cmd.Parameters.AddWithValue("@doctorId", appointment.DoctorId);
            cmd.Parameters.AddWithValue("@date", appointment.Date);
            
            await conn.OpenAsync();
            var newId = await cmd.ExecuteNonQueryAsync();
        }
    }
}