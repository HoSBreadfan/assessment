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
            var orderSummary = new OrderSummaryModel
            {
                OrangeQuantity = order.OrangeQuantity,
                AppleQuantity = order.AppleQuantity
            };

            return orderSummary;
        }
    }
}
