using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;

namespace SkiSchool.Application.Reports.Queries.GetReportById;
public class GetReportByIdQuery : IRequest<ReportDto>
{
    public int Id { get; set; }
}
public class GetReportByIdQueryHandler : IRequestHandler<GetReportByIdQuery, ReportDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReportByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<ReportDto> Handle(GetReportByIdQuery request, CancellationToken cancellationToken)
    {
        var eq = await _context.Report.SingleAsync(eq => eq.Id == request.Id);

        return _mapper.Map<ReportDto>(eq);

    }
}
