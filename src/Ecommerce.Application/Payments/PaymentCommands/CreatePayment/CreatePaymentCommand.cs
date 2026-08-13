using MediatR;

namespace Ecommerce.Application.Payments.PaymentCommands.CreatePayment;

public class CreatePaymentCommand : IRequest<CreatePaymentResponse>
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
}

public class CreatePaymentResponse
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}
