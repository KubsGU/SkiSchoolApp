using MediatR;
using SkiSchool.Application.Common.Exceptions;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Rentals.Commands.DeleteRental;
public class DeleteRentalCommand : IRequest

{
    public int Id { get; set; }
}

public class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteRentalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Rental.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Rental), request.Id);
        }

        //soft Deletion!
        entity.IsCancelled = true;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
