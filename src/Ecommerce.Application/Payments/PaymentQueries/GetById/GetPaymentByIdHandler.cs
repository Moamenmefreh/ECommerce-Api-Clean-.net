using Ecommerce.Domain.AggregateRootes.Payments.Repository;
using MediatR;

namespace Ecommerce.Application.Payments.PaymentQueries.GetById;

public class GetPaymentByIdHandler(IPaymentMethodRepository paymentRepository) : IRequestHandler<GetPaymentByIdQuery, Ecommerce.Domain.AggregateRootes.Payments.Entities.PaymentMethod>
{
    public async Task<Ecommerce.Domain.AggregateRootes.Payments.Entities.PaymentMethod> Handle(GetPaymentByIdQuery request, CancellationToken cancellationToken)
    {
        var payment = await paymentRepository.GetById(request.Id);
        return payment;
    }
}
