using Ecommerce.Application.Order.OrderCommands.CreateOrder;
using Ecommerce.Domain.AggregateRootes.Carts.Repository;
using Ecommerce.Domain.AggregateRootes.Orders.Repository;
using Ecommerce.Domain.BaseEntity;
using MediatR;

namespace Ecommerce.Application.Orders.OrderCommands.CreateOrder;

public class CreateOrderHandler(
    ICartRepository cartRepository,
    IOrderRepository orderRepository,
    ICurrentUserService currentUserService)
    : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    public async Task<CreateOrderResponse> Handle(
        CreateOrderCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var currentUserId = currentUserService.UserId;

            if (currentUserId == null)
            {
                return new CreateOrderResponse
                {
                    IsSuccess = false,
                    Message = "User is not authenticated."
                };
            }

            // الحصول على السلة الخاصة بالمستخدم الحالي
            var cart = cartRepository.GetByUserId(currentUserId.Value);

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

            // إنشاء Order للمستخدم الحالي
            var order = Ecommerce.Domain.AggregateRootes.Orders.Entities.Order.Create(
                currentUserId.Value);

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