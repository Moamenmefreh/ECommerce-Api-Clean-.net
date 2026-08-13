using MediatR;
using Ecommerce.Domain.AggregateRootes.Payments.Entities;

namespace Ecommerce.Application.Payments.PaymentQueries.GetById;

public class GetPaymentByIdQuery : IRequest<PaymentMethod>
{
    public Guid Id { get; set; }
}
