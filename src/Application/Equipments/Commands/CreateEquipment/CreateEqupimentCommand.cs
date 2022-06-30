using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Equipments.Commands.CreateEquipment;
public class CreateEquipmentCommand : IRequest<int>

{
    public string Name { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
}

public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEquipmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Equipment
        {
            IsActive = true,
            Name = request.Name,
            Price = request.Price,
            Type = request.Type
        };

        _context.Equipment.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
