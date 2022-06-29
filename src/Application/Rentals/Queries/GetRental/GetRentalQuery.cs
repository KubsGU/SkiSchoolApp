using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Rentals.Queries.GetRental;
public class GetRentalQuery : IRequest<PaginatedList<RentalDto>>
{ }
public class GetRentalQueryHandler : IRequestHandler<GetRentalQuery, PaginatedList<RentalDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRentalQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    async public Task<PaginatedList<RentalDto>> Handle(GetRentalQuery request, CancellationToken cancellationToken)
    {
        var rentalList = await _context.Rental.Where(r => !r.IsCancelled)
            .ProjectTo<RentalDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(1,1000);

        return rentalList;
    }
}
