using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Equipments.Queries.GetEquipmentsByType;
public class GetEquipmentsByTypeQuery : IRequest<PaginatedList<EquipmentDto>>
{
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
public class GetEquipmentsByTypeQueryHandler : IRequestHandler<GetEquipmentsByTypeQuery, PaginatedList<EquipmentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public GetEquipmentsByTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public Task<PaginatedList<EquipmentDto>> Handle(GetEquipmentsByTypeQuery request, CancellationToken cancellationToken)
    {

        //return null;
        var notAvailableEqIds = _context.Rental.Where(r => r.EndDate > request.StartDate && r.StartDate < request.EndDate).Select(r => r.Equipment.Id).ToList();

        var availableEquipment = _context.Equipment
            .Where(e => e.IsActive && e.Type.Equals(request.Type) && !notAvailableEqIds.Contains(e.Id))
            .ProjectTo<EquipmentDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(1, 1000);
        return availableEquipment;
        //TODO implement
    }
}


