using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Reports.Queries.GetReport;
public class GetReportQuery : IRequest<PaginatedList<ReportDto>>
{ }
public class GetReportQueryHandler : IRequestHandler<GetReportQuery, PaginatedList<ReportDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetReportQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    async public Task<PaginatedList<ReportDto>> Handle(GetReportQuery request, CancellationToken cancellationToken)
    {
        var eqList = await _context.Report
            .ProjectTo<ReportDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(1,1000);

        return eqList;
    }
}
