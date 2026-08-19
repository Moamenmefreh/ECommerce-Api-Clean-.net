using MediatR;
using Ecommerce.Domain.AggregateRootes.Payments.Entities;

namespace Ecommerce.Application.Payments.PaymentQueries.GetAll;

public class GetAllPaymentsQuery : IRequest<List<PaymentMethod>>
{
    public string? Name { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
