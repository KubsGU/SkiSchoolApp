using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;

namespace SkiSchool.Application.Reservations.Queries.GetReservationById;
public class GetReservationByIdQuery : IRequest<ReservationDto>
{
    public int Id { get; set; }
}
public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReservationByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var reservation = await _context.Reservation.SingleAsync(reservation => reservation.Id == request.Id);

        return _mapper.Map<ReservationDto>(reservation);

    }
}
