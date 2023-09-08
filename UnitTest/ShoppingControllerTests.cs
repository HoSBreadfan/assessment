﻿using Assessment.Controllers;
using Assessment.Model;
using Assessment.Service;

namespace UnitTest
{
    public class ShoppingControllerTests
    {
        [Theory]
        [InlineData(0, 0, 0.00, "$0.00")]
        [InlineData(3, 3, 1.70, "$1.70")]
        [InlineData(47, 34, 20.15, "$20.15")]
        public void PlaceOrder_Success(int apples, int oranges, double total, string totalString)
        {
            var shoppingService = new ShoppingService();
            var shoppingController = new ShoppingController(shoppingService);


            var orderModel = new OrderModel
            {
                AppleQuantity = apples,
                OrangeQuantity = oranges
            };

            var result = shoppingController.PlaceOrder(orderModel);

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
            var shoppingController = new ShoppingController(shoppingService);

            var orderModel = new OrderModel
            {
                AppleQuantity = apples,
                OrangeQuantity = oranges
            };

            Assert.Throws<Exception>(() => shoppingController.PlaceOrder(orderModel));
        }
    }
}
