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
        public IActionResult PlaceOrder([FromBody] OrderModel order)
        {
            if (order.AppleQuantity < 0 || order.OrangeQuantity < 0)
                return BadRequest();
            var orderSummary = _shoppingService.PlaceOrder(order);
            return Ok(orderSummary);
        }

        [HttpGet]
        [Route("Order")]
        public IActionResult GetOrder()
        {
            var orders = _shoppingService.GetOrders();

            return Ok(orders);
        }

        [HttpGet]
        [Route("Order/{orderId}")]
        public IActionResult GetOrder([FromRoute] string orderId)
        {
            var order = _shoppingService.GetOrderSummary(orderId);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
    }
}
