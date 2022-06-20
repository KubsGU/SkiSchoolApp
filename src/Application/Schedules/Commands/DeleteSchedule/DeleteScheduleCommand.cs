using MediatR;
using SkiSchool.Application.Common.Exceptions;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Schedules.Commands.DeleteSchedule;
public class DeleteScheduleCommand : IRequest

{
    public int Id { get; set; }
}

public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteScheduleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Schedule.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Schedule), request.Id);
        }

        _context.Schedule.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
