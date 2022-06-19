using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Equipments.Commands.CreateEquipment;
public class CreatePaymentCommand : IRequest<int>

{
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
    public Equipment Equipment { get; set; }
    public Timetable Timetable { get; set; }
    public bool Status { get; set; }
}

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreatePaymentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var entity = new Equipment
        {
            Price = request.Price,
            Date = request.Date,
            Equipment = request.Equipment,
            Timetable = request.Timetable,
            Status = request.Status
        };

        _context.Equipment.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
