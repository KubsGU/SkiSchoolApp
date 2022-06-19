namespace SkiSchool.Domain.Entities;
public class Rental
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Client Client { get; set; }
    public Equipment Equipment { get; set; }
    public bool IsCancelled { get; set; }
}
