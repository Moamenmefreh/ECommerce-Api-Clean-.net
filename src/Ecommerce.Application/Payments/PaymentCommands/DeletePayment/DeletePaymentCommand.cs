using MediatR;

namespace Ecommerce.Application.Payments.PaymentCommands.DeletePayment;

public class DeletePaymentCommand : IRequest<DeletePaymentResponse>
{
    public Guid Id { get; set; }
}

public class DeletePaymentResponse
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}
