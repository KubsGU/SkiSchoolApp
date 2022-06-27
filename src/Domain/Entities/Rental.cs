namespace SkiSchool.Domain.Entities;
public class Rental
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Client Client { get; set; }
    public bool IsCancelled { get; set; }
    public List<Reservation>? Reservations { get; set; }
}
