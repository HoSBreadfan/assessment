using Assessment.Model;
using Assessment.Service;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingService _shoppingService;
        public ShoppingController(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }



        [HttpPost]
        [Route("Order")]
        public OrderSummaryModel PlaceOrder([FromBody] OrderModel order)
        {
            var orderSummary = _shoppingService.PlaceOrder(order);
            return orderSummary;
        }
    }
}
