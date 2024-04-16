using Microsoft.AspNetCore.Mvc;

namespace APBD_Zadanie_4.Controllers;


[Route("api/animals/{animalId}/appointments")]
[ApiController]
public class AppointmentController : ControllerBase
{
    private static List<Appointment> appointments = new List<Appointment>();
    
    [HttpGet]
    public ActionResult<List<Appointment>> GetAppointmentsForAnimal(int animalId)
    {
        return appointments.Where(a => a.Animal.Id == animalId).ToList();
    }
    
    [HttpPost]
    public ActionResult<Appointment> AddAppointment(int animalId, Appointment appointment)
    {
        appointment.Animal.Id = animalId;
        appointments.Add(appointment);
        return CreatedAtAction("GetAppointmentsForAnimal", new { animalId = appointment.Animal.Id }, appointment);
    }
}