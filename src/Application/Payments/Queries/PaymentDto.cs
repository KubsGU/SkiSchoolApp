using SkiSchool.Application.Common.Mappings;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Payments.Queries;

public class PaymentDto : IMapFrom<Payment>
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public Equipment Equipment { get; set; }
    public Timetable Timetable { get; set; }
    public bool Status { get; set; }
}
