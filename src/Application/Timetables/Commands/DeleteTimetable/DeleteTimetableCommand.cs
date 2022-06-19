using MediatR;
using SkiSchool.Application.Common.Exceptions;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Timetables.Commands.DeleteTimetable;
public class DeleteTimetableCommand : IRequest

{
    public int Id { get; set; }
}

public class DeleteTimetableCommandHandler : IRequestHandler<DeleteTimetableCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTimetableCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteTimetableCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Timetable.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Timetable), request.Id);
        }

        _context.Timetable.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
