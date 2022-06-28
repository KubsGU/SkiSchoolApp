using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;

namespace SkiSchool.Application.Reports.Queries.ExportReport;
public record ExportRecordQuery : IRequest<ReportDto>
{
    public string Type { get; set; }
    public string Name { get; set; }

}

public class ExportRecordQueryHandler : IRequestHandler<ExportRecordQuery, ReportDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICsvFileBuilder _fileBuilder;
    private readonly IDateTime _dateTime;

    public ExportRecordQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder, IDateTime dateTime)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
        _dateTime = dateTime;
    }

    public async Task<ReportDto> Handle(ExportRecordQuery request, CancellationToken cancellationToken)
    {
        //Todo use Type
       /* var records = await _context.Payment
                .Where(p => p.Date >= _dateTime.Today)
                .Include(p => p.Timetable)
                .ProjectTo<TimetableReportRecord>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

        var vm = new ReportDto()
        {
            Name = request.Name + ".csv",
            Type = request.Type,
            Data = _fileBuilder.BuildPaymentFile(records)
        };          */

        return null;
    }
}