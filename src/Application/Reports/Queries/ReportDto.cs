using SkiSchool.Application.Common.Mappings;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Reports.Queries;
public class ReportDto :IMapFrom<Report>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public byte[] Data { get; set; }
}
