using Ecommerce.Domain.AggregateRootes.Payments.Entities;

namespace Ecommerce.Domain.AggregateRootes.Payments.Repository;

public interface IPaymentMethodRepository
{
    public Task<PaymentMethod> GetById(Guid id);

    public Task<List<PaymentMethod>> GetAll(string? name, int pageNumber, int pageSize);

    public void Add(PaymentMethod paymentMethod);

    public void Update(PaymentMethod paymentMethod);

    public void Delete(PaymentMethod paymentMethod);
}
