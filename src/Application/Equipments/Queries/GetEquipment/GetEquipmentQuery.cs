using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Equipments.Queries.GetEquipment;
public class GetEquipmentQuery : IRequest<PaginatedList<EquipmentDto>>
{ }
public class GetEquipmentQueryHandler : IRequestHandler<GetEquipmentQuery, PaginatedList<EquipmentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEquipmentQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    async public Task<PaginatedList<EquipmentDto>> Handle(GetEquipmentQuery request, CancellationToken cancellationToken)
    {
        var eqList = await _context.Equipment.Where(eq => eq.IsActive)
            .ProjectTo<EquipmentDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(1,1000);

        return eqList;
    }
}
