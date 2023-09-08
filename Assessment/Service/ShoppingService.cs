using Assessment.DAL;
using Assessment.Model;

namespace Assessment.Service
{
    public interface IShoppingService
    {
        OrderSummaryModel PlaceOrder(OrderModel order);
    }

    public class ShoppingService : IShoppingService
    {
        private readonly IOrderRepository _orderRepository;

        public ShoppingService(IOrderRepository orderRepository) 
        { 
            _orderRepository = orderRepository;
        }

        public OrderSummaryModel PlaceOrder(OrderModel order)
        {
            if (order.AppleQuantity < 0 || order.OrangeQuantity < 0)
                throw new Exception("Order Quantity cannot be less than 0");

            var orderSummary = new OrderSummaryModel(order.OrangeQuantity, order.AppleQuantity);

            _orderRepository.AddOrderSummary(orderSummary);

            return orderSummary;
        }

        public OrderSummaryModel GetOrderSummary(string Id)
        {
            return _orderRepository.GetOrderSummary(Id);
        }

        public IList<OrderSummaryModel> GetOrders()
        {
            return _orderRepository.GetOrderSummaries();
        }
    }
}
