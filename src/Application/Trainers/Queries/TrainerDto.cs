using SkiSchool.Application.Common.Mappings;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Trainers.Queries;
public class TrainerDto : IMapFrom<Trainer>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal Price { get; set; }
    public string TypeOfService { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}
