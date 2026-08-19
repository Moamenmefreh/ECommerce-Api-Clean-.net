using Ecommerce.Domain.AggregateRootes.Payments.Entities;
using Ecommerce.Domain.AggregateRootes.Payments.Repository;
using MediatR;

namespace Ecommerce.Application.Payments.PaymentCommands.CreatePayment;

public class CreatePaymentHandler(IPaymentMethodRepository paymentRepository) : IRequestHandler<CreatePaymentCommand, CreatePaymentResponse>
{
    public async Task<CreatePaymentResponse> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        try
        {
            var payment = PaymentMethod.Create(request.Name, request.Description);
            paymentRepository.Add(payment);
            return new CreatePaymentResponse { IsSuccess = true, Message = "Payment method created successfully." };
        }
        catch (Exception ex)
        {
            return new CreatePaymentResponse { IsSuccess = false, Message = ex.Message };
        }
    }
}
