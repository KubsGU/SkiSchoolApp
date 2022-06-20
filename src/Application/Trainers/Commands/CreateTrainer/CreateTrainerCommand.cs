using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Trainers.Commands.CreateTrainer;
public class CreateTrainerCommand : IRequest<int>

{
    public string Name { get; set; }
    public string Surname { get; set; }
    public decimal Price { get; set; }
    public string TypeOfService { get; set; }
    public bool IsActive { get; set; }
}

public class CreateTrainerCommandHandler : IRequestHandler<CreateTrainerCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTrainerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTrainerCommand request, CancellationToken cancellationToken)
    {
        var entity = new Trainer
        {
            Surname = request.Surname,
            Name = request.Name,
            Price = request.Price,
            TypeOfService = request.TypeOfService,
            IsActive = request.IsActive
        };

        _context.Trainer.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
