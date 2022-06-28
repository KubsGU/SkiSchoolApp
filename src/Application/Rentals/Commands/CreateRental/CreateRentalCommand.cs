using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Rentals.Commands.CreateRental;
public class CreateRentalCommand : IRequest<int>

{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ClientId { get; set; }
    public List<int>? EquipmentId { get; set; }
    public bool IsCancelled { get; set; } = false;
}

public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateRentalCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
    {
        var client = await _context.Client.FindAsync(request.ClientId);

        var listOfReservations = request.EquipmentId.Select(eq => new Reservation() { EquipmentId = eq }).ToList();
        var entity = new Rental
        {
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            ClientId = request.ClientId,
            Reservations = listOfReservations,
            IsCancelled = request.IsCancelled
        };
        _context.Rental.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
