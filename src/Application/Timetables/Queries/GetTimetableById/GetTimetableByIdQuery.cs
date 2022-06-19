using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;

namespace SkiSchool.Application.Timetables.Queries.GetTimetableById;
public class GetTimetableByIdQuery : IRequest<TimetableDto>
{
    public int Id { get; set; }
}
public class GetTimetableByIdQueryHandler : IRequestHandler<GetTimetableByIdQuery, TimetableDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTimetableByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<TimetableDto> Handle(GetTimetableByIdQuery request, CancellationToken cancellationToken)
    {
        var eq = await _context.Timetable.SingleAsync(eq => eq.Id == request.Id);

        return _mapper.Map<TimetableDto>(eq);

    }
}
