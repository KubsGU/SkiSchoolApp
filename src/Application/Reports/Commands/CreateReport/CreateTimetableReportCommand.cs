using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Reports.Commands.CreateReport;
public class CreateTimetableReportCommand : IRequest<int>

{
    public string Name { get; set; }
}

public class CreateTimetableReportCommandHandler : IRequestHandler<CreateTimetableReportCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICsvFileBuilder _fileBuilder;
    private readonly IDateTime _dateTime;

    public CreateTimetableReportCommandHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder, IDateTime dateTime)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
        _dateTime = dateTime;
    }
    public async Task<int> Handle(CreateTimetableReportCommand request, CancellationToken cancellationToken)
    {
        //TODO improve
        var records = await _context.Payment
              .Where(p => p.Date >= _dateTime.Today && p.Timetable != null)
              .ProjectTo<TimetableReportRecord>(_mapper.ConfigurationProvider)
              .ToListAsync(cancellationToken);

        var entity = new Report()
        {
            Name = request.Name + ".csv",
            Type = "TimeTables",
            Data = _fileBuilder.BuildTimetableReportFile(records)
        };

        _context.Report.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

}
