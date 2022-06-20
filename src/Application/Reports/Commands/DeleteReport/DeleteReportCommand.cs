using MediatR;
using SkiSchool.Application.Common.Exceptions;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Reports.Commands.DeleteReport;
public class DeleteReportCommand : IRequest

{
    public int Id { get; set; }
}

public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteReportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Report.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Report), request.Id);
        }

        _context.Report.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
