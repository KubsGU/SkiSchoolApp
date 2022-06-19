using SkiSchool.Application.Common.Mappings;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Reservations.Queries;
public class ReservationDto : IMapFrom<Reservation>
{
    public int Id { get; set; }
    public Rental Rental { get; set; }
    public Equipment Equipment { get; set; }
}
