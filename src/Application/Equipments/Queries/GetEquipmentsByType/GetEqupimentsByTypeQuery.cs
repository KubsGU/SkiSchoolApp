using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Equipments.Queries.GetEquipmentsByType;
public class GetEquipmentsByTypeQuery : IRequest<List<EquipmentDto>>
{
    public string Type { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
public class GetEquipmentsByTypeQueryHandler : IRequestHandler<GetEquipmentsByTypeQuery, List<EquipmentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public GetEquipmentsByTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<List<EquipmentDto>> Handle(GetEquipmentsByTypeQuery request, CancellationToken cancellationToken)
    {

        //return null;
        var notAvailableEqids = _context.Rental.Include(r => r.Reservations).Where(r => r.EndDate > request.StartDate && r.StartDate < request.EndDate).ToList().Select(r => r.Reservations?.Select(eq => eq.EquipmentId)).ToList();


        List<int> Temp = new List<int>();
        foreach (var eq in notAvailableEqids)
        {
            eq.ToList().ForEach(equ => Temp.Add(equ));
        }


        return await _context.Equipment.Where(e => e.IsActive && e.Type.Equals(request.Type) && !Temp.Contains(e.Id))
            .ProjectToListAsync<EquipmentDto>(_mapper.ConfigurationProvider);

    }
}


