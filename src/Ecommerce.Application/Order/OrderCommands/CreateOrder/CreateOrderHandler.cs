using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using Ecommerce.Domain.AggregateRootes.Orders.Repository;
using Ecommerce.Domain.AggregateRootes.Orders.Entities;
using MediatR;

 namespace Ecommerce.Application.Order.OrderCommands.CreateOrder;

public class CreateOrderHandler(
    ICartRepository cartRepository,
    IOrderRepository orderRepository)
    : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    public async Task<CreateOrderResponse> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            // الحصول على السلة الخاصة بالمستخدم
            var cart = cartRepository.GetByUserId(request.UserId);

            if (cart == null)
            {
                return new CreateOrderResponse
                {
                    IsSuccess = false,
                    Message = "Cart not found."
                };
            }

            if (!cart.CartItems.Any())
            {
                return new CreateOrderResponse
                {
                    IsSuccess = false,
                    Message = "Cart is empty."
                };
            }

            // إنشاء Order
            var order = Ecommerce.Domain.AggregateRootes.Orders.Entities.Order.Create(request.UserId);
<<<<<<<< HEAD:src/Ecommerce.Application/Order/OrderCommands/CreateOrder/CreateOrderHandler.cs
========

>>>>>>>> main:src/Ecommerce.Application/Order/CreateOrder/CreateOrderHandler.cs
            // نقل عناصر السلة إلى الطلب
            foreach (var item in cart.CartItems)
            {
                order.AddItem(
                    item.ProductId,
                    item.Quentity,
                    item.UnitPrice);
            }

            // حفظ الطلب
            orderRepository.Add(order);

            // تفريغ السلة
            cartRepository.ClearCart(cart);

            return new CreateOrderResponse
            {
                OrderId = order.Id,
                IsSuccess = true,
                Message = "Order created successfully."
            };
        }
        catch (Exception ex)
        {
            return new CreateOrderResponse
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
}