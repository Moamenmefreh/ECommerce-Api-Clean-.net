using Ecommerce.Domain.AggregateRootes.Payments.Entities;
using Ecommerce.Domain.AggregateRootes.Payments.Repository;

namespace Ecommerce.Presistance.Repository;

public class PaymentRepository(AppdbContext dbContext) : IPaymentMethodRepository
{
    public void Add(PaymentMethod paymentMethod)
    {
        dbContext.Set<PaymentMethod>().Add(paymentMethod);
        dbContext.SaveChanges();
    }

    public void Delete(PaymentMethod paymentMethod)
    {
        dbContext.Set<PaymentMethod>().Remove(paymentMethod);
        dbContext.SaveChanges();
    }

    public async Task<List<PaymentMethod>> GetAll(string? name, int pageNumber, int pageSize)
    {
        var list = dbContext.Set<PaymentMethod>().ToList();
        if (!string.IsNullOrEmpty(name))
            list = list.Where(x => x.Name.Contains(name)).ToList();

        return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
    }

    public async Task<PaymentMethod> GetById(Guid id)
    {
        var entity = dbContext.Set<PaymentMethod>().Find(id);
        return entity!;
    }

    public void Update(PaymentMethod paymentMethod)
    {
        dbContext.Set<PaymentMethod>().Update(paymentMethod);
        dbContext.SaveChanges();
    }
}
