using Assessment.Model;

namespace Assessment.DAL
{
    public interface IOrderRepository
    {
        void AddOrderSummary(OrderSummaryModel orderSummary);
        OrderSummaryModel GetOrderSummary(string id);
        IList<OrderSummaryModel> GetOrderSummaries();
    }

    public class OrderRepository : IOrderRepository
    {
        //  This is a 'database'
        private List<OrderSummaryModel> _orderSummaries = new List<OrderSummaryModel>();


        public void AddOrderSummary(OrderSummaryModel orderSummary)
        {
            _orderSummaries.Add(orderSummary);
        }

        public OrderSummaryModel GetOrderSummary(string id)
        {
            return _orderSummaries.FirstOrDefault(x => string.Equals(x.Id, id));
        }

        public IList<OrderSummaryModel> GetOrderSummaries()
        {  
            return _orderSummaries;
        }
    }
}
