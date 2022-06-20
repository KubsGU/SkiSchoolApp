using SkiSchool.Application.Common.Mappings;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Timetables.Queries;
public class TimetableDto : IMapFrom<Timetable>
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Trainer Trainer { get; set; }
    public Client Client { get; set; }
    public bool IsCancelled { get; set; }
}
