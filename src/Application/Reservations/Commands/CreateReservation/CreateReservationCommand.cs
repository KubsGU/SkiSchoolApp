using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Reservations.Commands.CreateReservation;
public class CreateReservationCommand : IRequest<int>

{
    public int RentalId { get; set; }
    public int EquipmentId { get; set; }
}

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateReservationCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var rental = await _context.Rental.FindAsync(request.RentalId);
        var equipment = await _context.Equipment.FindAsync(request.EquipmentId);
        var entity = new Reservation
        {
            Rental = rental,
            Equipment = equipment,
        };

        _context.Reservation.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
