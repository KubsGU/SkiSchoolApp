using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Rentals.Commands.CreateRental;
public class CreateRentalCommand : IRequest<int>

{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Client Client { get; set; }
    public List<Reservation>? Reservations { get; set; }
    public bool IsCancelled { get; set; }
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
        var entity = new Rental
        {
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Client = request.Client,
            IsCancelled = request.IsCancelled
        };
        //TODO FIX
        _context.Rental.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
