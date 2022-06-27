using MediatR;
using SkiSchool.Application.Common.Exceptions;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Trainers.Commands.DeleteTrainer;
public class DeleteTrainerCommand : IRequest

{
    public int Id { get; set; }
}

public class DeleteTrainerCommandHandler : IRequestHandler<DeleteTrainerCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteTrainerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteTrainerCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Trainer.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Trainer), request.Id);
        }
        //soft Deletion!
        entity.IsActive = false;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
