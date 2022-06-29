using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Equipments.Queries.GetEquipmentTypes;
public class GetEqupimentTypesQuery : IRequest<PaginatedList<string>>
{
    //TODO add pagination
}

public class GetEqupimentTypesQueryHandler : IRequestHandler<GetEqupimentTypesQuery, PaginatedList<string>>
{
    private readonly IApplicationDbContext _context;

    public GetEqupimentTypesQueryHandler(IApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<PaginatedList<string>> Handle(GetEqupimentTypesQuery request, CancellationToken cancellationToken)
    {
        var types = await _context.Equipment.Where(eq => eq.IsActive).Select(e => e.Type).Distinct().PaginatedListAsync(1, 100);
        return types;
    }
}
