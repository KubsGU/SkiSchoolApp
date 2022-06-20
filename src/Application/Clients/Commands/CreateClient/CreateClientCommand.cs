using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Domain.Entities;

namespace SkiSchool.Application.Clients.Commands.CreateClient;

public class CreateClientCommand : IRequest<int>

{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IDNo { get; set; }
    public string Pesel { get; set; } // TODO: Rename Pesel in Client.cs
    public string PhoneNumber { get; set; }
}

public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateClientCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        var entity = new Client
        {
            Surname = request.Surname,
            Name = request.Name,
            Email = request.Email,
            IDNo = request.IDNo,
            Pesel = request.Pesel,
            PhoneNumber = request.PhoneNumber,
        };

        _context.Client.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

}
