namespace SkiSchool.Domain.Entities;
public class Timetable
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TrainerId { get; set; }
    public Trainer Trainer { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public bool IsCancelled { get; set; }
}
