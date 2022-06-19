using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using SkiSchool.Application.Common.Interfaces;
using SkiSchool.Application.Common.Mappings;
using SkiSchool.Application.Common.Models;

namespace SkiSchool.Application.Payments.Queries.GetPayment;
public class GetPaymentQuery : IRequest<PaginatedList<PaymentDto>>
{ }
public class GetPaymentQueryHandler : IRequestHandler<GetPaymentQuery, PaginatedList<PaymentDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPaymentQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }


    async public Task<PaginatedList<PaymentDto>> Handle(GetPaymentQuery request, CancellationToken cancellationToken)
    {
        var eqList = await _context.Payment
            .ProjectTo<PaymentDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(1, 1000);

        return eqList;
    }
}
