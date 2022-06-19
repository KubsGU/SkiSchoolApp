using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;

namespace SkiSchool.Application.Schedules.Queries.GetScheduleById;
public class GetScheduleByIdQuery : IRequest<ScheduleDto>
{
    public int Id { get; set; }
}
public class GetScheduleByIdQueryHandler : IRequestHandler<GetScheduleByIdQuery, ScheduleDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetScheduleByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<ScheduleDto> Handle(GetScheduleByIdQuery request, CancellationToken cancellationToken)
    {
        var eq = await _context.Schedule.SingleAsync(eq => eq.Id == request.Id);

        return _mapper.Map<ScheduleDto>(eq);

    }
}
