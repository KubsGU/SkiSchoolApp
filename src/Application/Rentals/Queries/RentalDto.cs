using SkiSchool.Application.Common.Mappings;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Rentals.Queries;
public class RentalDto :IMapFrom<Rental>
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Client Client { get; set; }
    public Equipment Equipment { get; set; }
    public bool IsCancelled { get; set; }
}
