using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;

namespace SkiSchool.Application.Trainers.Queries.GetTrainerById;
public class GetTrainerByIdQuery : IRequest<TrainerDto>
{
    public int Id { get; set; }
}
public class GetTrainerByIdQueryHandler : IRequestHandler<GetTrainerByIdQuery, TrainerDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTrainerByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    public async Task<TrainerDto> Handle(GetTrainerByIdQuery request, CancellationToken cancellationToken)
    {
        var eq = await _context.Trainer.SingleAsync(eq => eq.Id == request.Id);

        return _mapper.Map<TrainerDto>(eq);

    }
}
