using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Reservations.Queries.GetReservation;
public class GetReservationQuery : IRequest<PaginatedList<ReservationDto>>
{ }
public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, PaginatedList<ReservationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReservationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    async public Task<PaginatedList<ReservationDto>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        var reservationList = await _context.Reservation
            .ProjectTo<ReservationDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(1,1000);

        return reservationList;
    }
}
