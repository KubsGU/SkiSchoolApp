using MediatR;
using SkiSchool.Application.Common.Exceptions;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Clients.Commands.DeleteClient;

public class DeleteClientCommand : IRequest

{
    public int Id { get; set; }
}

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteClientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Client.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Client), request.Id);
        }

        _context.Client.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}