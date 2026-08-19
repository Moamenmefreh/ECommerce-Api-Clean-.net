using Ecommerce.Domain.AggregateRootes.Payments.Repository;
using MediatR;

namespace Ecommerce.Application.Payments.PaymentQueries.GetAll;

public class GetAllPaymentsHandler(IPaymentMethodRepository paymentRepository) : IRequestHandler<GetAllPaymentsQuery, List<Ecommerce.Domain.AggregateRootes.Payments.Entities.PaymentMethod>>
{
    public async Task<List<Ecommerce.Domain.AggregateRootes.Payments.Entities.PaymentMethod>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
    {
        var list = await paymentRepository.GetAll(request.Name, request.PageNumber, request.PageSize);
        return list;
    }
}
