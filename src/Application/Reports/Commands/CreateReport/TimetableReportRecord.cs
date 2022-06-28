using AutoMapper;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Reports.Commands.CreateReport;
public class TimetableReportRecord
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string ClientFullName { get; set; }
    public string ClientPesel { get; set; }
    public string TrainerFullName { get; set; }
    public string TypeOfService { get; set; }
    public bool Status { get; set; }
}
