using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Trainers.Queries.GetTrainer;
public class GetAvailableTrainersQuery : IRequest<List<TrainerDto>>
{ 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
public class GetAvailableTrainersQueryHandler: IRequestHandler<GetAvailableTrainersQuery, List<TrainerDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAvailableTrainersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    async public Task<List<TrainerDto>> Handle(GetAvailableTrainersQuery request, CancellationToken cancellationToken)
    {

        var notAvailableDueToTimetable = await _context.Timetable.Where(t => t.EndDate > request.StartDate && t.StartDate < request.EndDate).Select(t => t.TrainerId).ToListAsync();

        var startHour = DateTime.Parse(request.StartDate.ToString("HH:mm"));
        var endHour =  DateTime.Parse(request.EndDate.ToString("HH:mm"));


        var allTrainers =  await _context.Trainer
            .Include(t => t.Schedule)
            .ProjectToListAsync<TrainerDto>(_mapper.ConfigurationProvider);

        var availableTrainers = allTrainers
            .Where(t => DateTime.Parse(t.StartTime) <= startHour
            && DateTime.Parse(t.EndTime) >= endHour
            && !notAvailableDueToTimetable.Contains(t.Id)).ToList();


        return availableTrainers;
    }
}
