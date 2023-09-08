using Assessment.Model;
using Assessment.Service;
using System.ComponentModel.DataAnnotations;

namespace UnitTest
{
    public class ShoppingServiceTests
    {
        [Theory]
        [InlineData(0, 0, 0.00, "$0.00")]
        [InlineData(3, 3, 2.55, "$2.55")]
        public void PlaceOrder_Success(int apples, int oranges, double total, string totalString)
        {
            var shoppingService = new ShoppingService();
            var orderModel = new OrderModel
            {
                AppleQuantity = apples,
                OrangeQuantity = oranges
            };

            var result = shoppingService.PlaceOrder(orderModel);

            Assert.True(result.AppleQuantity == apples);
            Assert.True(result.OrangeQuantity == oranges);
            Assert.True(result.TotalCost == total);
            Assert.True(result.TotalDollarCost == totalString);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(3, -3)]
        public void PlaceOrder_BadParameter(int apples, int oranges)
        {
            var shoppingService = new ShoppingService();
            var orderModel = new OrderModel
            {
                AppleQuantity = apples,
                OrangeQuantity = oranges
            };

            Assert.Throws<Exception>(() => shoppingService.PlaceOrder(orderModel));
        }
    }
}