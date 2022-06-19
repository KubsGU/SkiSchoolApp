using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Clients.Queries.GetClient;
public class GetClientQuery : IRequest<PaginatedList<ClienttDto>>
{ }
public class GetClientQueryHandler : IRequestHandler<GetClientQuery, PaginatedList<ClientDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetClientQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    async public Task<PaginatedList<ClientDto>> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {
        var eqList = await _context.Client
            .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(1, 1000);

        return eqList;
    }
}