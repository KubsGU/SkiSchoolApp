using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Trainers.Queries.GetTrainer;
public class GetTrainerQuery : IRequest<PaginatedList<TrainerDto>>
{ }
public class GetTrainerQueryHandler : IRequestHandler<GetTrainerQuery, PaginatedList<TrainerDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTrainerQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    async public Task<PaginatedList<TrainerDto>> Handle(GetTrainerQuery request, CancellationToken cancellationToken)
    {
        var trainerList = await _context.Trainer.Include(t => t.Schedule).Where(t => t.IsActive)
            .ProjectTo<TrainerDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(1,1000);

        return trainerList;
    }
}
