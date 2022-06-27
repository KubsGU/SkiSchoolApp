using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Payments.Commands.CreatePayment;
public class CreatePaymentCommand : IRequest<int>

{
    public decimal Price { get; set; }
    public int DateId { get; set; }
    public int RentalId { get; set; }
    public int TimetableId { get; set; }
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
        var date = await _context.Client.FindAsync(request.DateId);
        var rental = await _context.Trainer.FindAsync(request.RentalId);
        var timetable = await _context.Trainer.FindAsync(request.TimetableId);
        var entity = new Payment
        {
            Price = request.Price,
            Date = date,
            Rental = rental,
            Timetable = timetable,
            Status = request.Status
        };

        _context.Payment.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
