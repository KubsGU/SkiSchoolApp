using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Timetables.Commands.CreateTimetable;
public class CreateTimetableCommand : IRequest<int>

{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TrainerId { get; set; }
    public int ClientId { get; set; }
    public bool IsCancelled { get; set; } = false;
}

public class CreateTimetableCommandHandler : IRequestHandler<CreateTimetableCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTimetableCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTimetableCommand request, CancellationToken cancellationToken)
    {
        var entity = new Timetable
        {
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            TrainerId = request.TrainerId,
            ClientId = request.ClientId,
            IsCancelled = request.IsCancelled
        };

        _context.Timetable.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
