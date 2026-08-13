using Ecommerce.Domain.AggregateRootes.Payments.Repository;
using MediatR;

namespace Ecommerce.Application.Payments.PaymentCommands.UpdatePayment;

public class UpdatePaymentHandler(IPaymentMethodRepository paymentRepository) : IRequestHandler<UpdatePaymentCommand, UpdatePaymentResponse>
{
    public async Task<UpdatePaymentResponse> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        try
        {
            var payment = await paymentRepository.GetById(request.Id);
            if (payment == null)
            {
                return new UpdatePaymentResponse { IsSuccess = false, Message = "Payment method not found." };
            }

            payment.Update(request.Name, request.Description, request.IsActive);
            paymentRepository.Update(payment);

            return new UpdatePaymentResponse { IsSuccess = true, Message = "Payment method updated successfully." };
        }
        catch (Exception ex)
        {
            return new UpdatePaymentResponse { IsSuccess = false, Message = ex.Message };
        }
    }
}
