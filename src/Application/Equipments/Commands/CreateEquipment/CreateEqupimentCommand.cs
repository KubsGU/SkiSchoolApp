using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Equipments.Commands.CreateEquipment;
public class CreateEqupimentCommand : IRequest<int>

{
    public string Name { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
}

public class CreateEqupimentCommandHandler : IRequestHandler<CreateEqupimentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEqupimentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEqupimentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Equipment
        {
            IsActive = request.IsActive,
            Name = request.Name,
            Price = request.Price,
            Type = request.Type
        };

        _context.Equipment.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
