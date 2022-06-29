using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Reports.Commands.CreateRentalReport;
public class CreateRentalReportCommand : IRequest<int>

{
    public string Name { get; set; }
}

public class CreateRentalReportCommandHandler : IRequestHandler<CreateRentalReportCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICsvFileBuilder _fileBuilder;
    private readonly IDateTime _dateTime;

    public CreateRentalReportCommandHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder, IDateTime dateTime)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
        _dateTime = dateTime;
    }
    public async Task<int> Handle(CreateRentalReportCommand request, CancellationToken cancellationToken)
    {
        //TODO improve
        var records = await _context.Payment
              .Where(p => p.Date >= _dateTime.Today && p.Rental != null)
              .Include(p => p.Rental)
              .ProjectTo<RentalReportRecord>(_mapper.ConfigurationProvider)
              .ToListAsync(cancellationToken);

        var entity = new Report()
        {
            Name = request.Name + ".csv",
            Type = "Rentals",
            Data = _fileBuilder.BuildRentalReportFile(records)
        };

        _context.Report.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }

}