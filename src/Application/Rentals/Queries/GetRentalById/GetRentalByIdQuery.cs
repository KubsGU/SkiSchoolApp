using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;

namespace SkiSchool.Application.Rentals.Queries.GetRentalById;
public class GetRentalByIdQuery : IRequest<RentalDto>
{
    public int Id { get; set; }
}
public class GetRentalByIdQueryHandler : IRequestHandler<GetRentalByIdQuery, RentalDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRentalByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<RentalDto> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
    {
        var rental = await _context.Rental.Include(r => r.Reservations).ThenInclude(r => r.Equipment).SingleAsync(rental => rental.Id == request.Id);

        return _mapper.Map<RentalDto>(rental);
    }
}
