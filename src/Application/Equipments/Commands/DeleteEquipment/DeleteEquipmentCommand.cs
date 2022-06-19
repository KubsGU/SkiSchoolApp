using MediatR;
using SkiSchool.Application.Common.Exceptions;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Equipments.Commands.DeleteEquipment;
public class DeleteEquipmentCommand : IRequest

{
    public int Id { get; set; }
}

public class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteEquipmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Equipment.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Equipment), request.Id);
        }

        _context.Equipment.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
