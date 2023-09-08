using Assessment.Model;

namespace Assessment.Service
{
    public interface IShoppingService
    {
        OrderSummaryModel PlaceOrder(OrderModel order);
    }

    public class ShoppingService : IShoppingService
    {
        public OrderSummaryModel PlaceOrder(OrderModel order)
        {
            if (order.AppleQuantity < 0 || order.OrangeQuantity < 0)
                throw new Exception("Order Quantity cannot be less than 0");

            var orderSummary = new OrderSummaryModel(order.OrangeQuantity, order.AppleQuantity);

            return orderSummary;
        }
    }
}
