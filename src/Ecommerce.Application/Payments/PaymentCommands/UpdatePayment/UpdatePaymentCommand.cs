using MediatR;

namespace Ecommerce.Application.Payments.PaymentCommands.UpdatePayment;

public class UpdatePaymentCommand : IRequest<UpdatePaymentResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}

public class UpdatePaymentResponse
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
}
