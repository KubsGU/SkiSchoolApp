using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Schedules.Commands.CreateSchedule;
public class CreateScheduleCommand : IRequest<int>

{
    public string DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int TrainerId { get; set; }
}

public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateScheduleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
    {
        var trainer = await _context.Trainer.FindAsync(request.TrainerId);
        var entity = new Schedule
        {
            DayOfWeek = request.DayOfWeek,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            Trainer = trainer
        };

        _context.Schedule.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
