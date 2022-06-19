using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Schedules.Queries.GetSchedule;
public class GetScheduleQuery : IRequest<PaginatedList<ScheduleDto>>
{ }
public class GetScheduleQueryHandler : IRequestHandler<GetScheduleQuery, PaginatedList<ScheduleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetScheduleQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    async public Task<PaginatedList<ScheduleDto>> Handle(GetScheduleQuery request, CancellationToken cancellationToken)
    {
        var eqList = await _context.Schedule
            .ProjectTo<ScheduleDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(1,1000);

        return eqList;
    }
}
