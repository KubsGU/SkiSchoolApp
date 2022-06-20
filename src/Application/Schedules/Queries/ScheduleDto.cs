using SkiSchool.Application.Common.Mappings;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Schedules.Queries;
public class ScheduleDto :IMapFrom<Schedule>
{
    public int Id { get; set; }
    public string DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public Trainer Trainer { get; set; }
}
