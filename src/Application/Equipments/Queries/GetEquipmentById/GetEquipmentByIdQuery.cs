using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;

namespace SkiSchool.Application.Equipments.Queries.GetEquipmentById;
public class GetEquipmentByIdQuery : IRequest<EquipmentDto>
{
    public int Id { get; set; }
}
public class GetEquipmentByIdQueryHandler : IRequestHandler<GetEquipmentByIdQuery, EquipmentDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEquipmentByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<EquipmentDto> Handle(GetEquipmentByIdQuery request, CancellationToken cancellationToken)
    {
        var eq = await _context.Equipment.SingleAsync(eq => eq.Id == request.Id);

        return _mapper.Map<EquipmentDto>(eq);

    }
}
