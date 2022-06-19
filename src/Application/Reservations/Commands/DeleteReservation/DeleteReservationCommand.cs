using MediatR;
using SkiSchool.Application.Common.Exceptions;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Reservations.Commands.DeleteReservation;
public class DeleteReservationCommand : IRequest

{
    public int Id { get; set; }
}

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteReservationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Reservation.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Reservation), request.Id);
        }

        _context.Reservation.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
