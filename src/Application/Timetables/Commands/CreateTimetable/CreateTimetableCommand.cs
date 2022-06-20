using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Timetables.Commands.CreateTimetable;
public class CreateTimetableCommand : IRequest<int>

{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Trainer Trainer { get; set; }
    public Client Client { get; set; }
    public bool IsCancelled { get; set; }
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
            Trainer = request.Trainer,
            Client = request.Client,
            IsCancelled = request.IsCancelled
        };

        _context.Timetable.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
