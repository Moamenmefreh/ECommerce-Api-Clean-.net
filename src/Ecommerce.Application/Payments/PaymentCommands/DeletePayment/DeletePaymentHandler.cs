using Ecommerce.Domain.AggregateRootes.Payments.Repository;
using MediatR;

namespace Ecommerce.Application.Payments.PaymentCommands.DeletePayment;

public class DeletePaymentHandler(IPaymentMethodRepository paymentRepository) : IRequestHandler<DeletePaymentCommand, DeletePaymentResponse>
{
    public async Task<DeletePaymentResponse> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var payment = await paymentRepository.GetById(request.Id);
            if (payment == null)
            {
                return new DeletePaymentResponse { IsSuccess = false, Message = "Payment method not found." };
            }

            paymentRepository.Delete(payment);
            return new DeletePaymentResponse { IsSuccess = true, Message = "Payment method deleted successfully." };
        }
        catch (Exception ex)
        {
            return new DeletePaymentResponse { IsSuccess = false, Message = ex.Message };
        }
    }
}
