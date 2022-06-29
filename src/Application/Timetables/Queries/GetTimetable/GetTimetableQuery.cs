using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Timetables.Queries.GetTimetable;
public class GetTimetableQuery : IRequest<PaginatedList<TimetableDto>>
{ }
public class GetTimetableQueryHandler : IRequestHandler<GetTimetableQuery, PaginatedList<TimetableDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTimetableQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    async public Task<PaginatedList<TimetableDto>> Handle(GetTimetableQuery request, CancellationToken cancellationToken)
    {
        var timetableList = await _context.Timetable.Where(t => !t.IsCancelled)
            .ProjectTo<TimetableDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(1,1000);

        return timetableList;
    }
}
