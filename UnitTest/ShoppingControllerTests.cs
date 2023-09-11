using Assessment.Controllers;
using Assessment.DAL;
using Assessment.Model;
using Assessment.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace UnitTest
{
    public class ShoppingControllerTests
    {
        Mock<IShoppingService> shoppingServiceMock = new Mock<IShoppingService>();

        [Theory]
        [InlineData(0, 0, 0.00, "$0.00")]
        [InlineData(3, 3, 1.70, "$1.70")]
        [InlineData(47, 34, 20.15, "$20.15")]
        public void PlaceOrder_Success(int apples, int oranges, double total, string totalString)
        {
            var orderSummary = new OrderSummaryModel(oranges, apples);

            shoppingServiceMock.Setup(x => x.PlaceOrder(It.IsAny<OrderModel>())).Returns(orderSummary);
            var shoppingController = new ShoppingController(shoppingServiceMock.Object);


            var orderModel = new OrderModel
            {
                AppleQuantity = apples,
                OrangeQuantity = oranges
            };

            var okResult = shoppingController.PlaceOrder(orderModel) as OkObjectResult;
            var result = okResult.Value as OrderSummaryModel;

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
            shoppingServiceMock.Setup(x => x.PlaceOrder(It.IsAny<OrderModel>()));

            var shoppingController = new ShoppingController(shoppingServiceMock.Object);

            var orderModel = new OrderModel
            {
                AppleQuantity = apples,
                OrangeQuantity = oranges
            };

            var badRequestResult = shoppingController.PlaceOrder(orderModel) as BadRequestResult;
            Assert.True(badRequestResult.StatusCode == 400);
        }

        [Theory]
        [InlineData("1558bd1c-007f-44a5-bc73-ba554f7c316e")]
        public void GetOrder_Success(string orderId)
        {
            var testOrder = new OrderSummaryModel(3, 3);
            shoppingServiceMock.Setup(x => x.GetOrderSummary(orderId)).Returns(testOrder);

            var shoppingController = new ShoppingController(shoppingServiceMock.Object);

            var okResult = shoppingController.GetOrder(orderId) as OkObjectResult;
            var result = okResult.Value as OrderSummaryModel;

            Assert.True(result.Id == testOrder.Id);
            Assert.True(result.AppleQuantity == testOrder.AppleQuantity);
            Assert.True(result.OrangeQuantity == testOrder.OrangeQuantity);
            Assert.True(result.TotalCost == testOrder.TotalCost);
        }

        [Theory]
        [InlineData("1558bd1c-007f-44a5-bc73-ba554f7c316e")]
        public void GetOrder_NotFound(string orderId)
        {
            var shoppingController = new ShoppingController(shoppingServiceMock.Object);

            var result = shoppingController.GetOrder(orderId) as NotFoundResult;

            Assert.True(result.StatusCode == 404);
        }

        [Theory]
        [InlineData(3, 3, 87, 104)]
        [InlineData(18, 4, 0, 23)]
        public void GetOrders_Success(int appleOne, int orangeOne, int appleTwo, int orangeTwo)
        {
            var testOrder = new OrderSummaryModel(appleOne, orangeOne);
            var testOrder2 = new OrderSummaryModel(appleTwo, orangeTwo);

            var testOrders = new List<OrderSummaryModel>
            {
                testOrder,
                testOrder2
            };
            shoppingServiceMock.Setup(x => x.GetOrders()).Returns(testOrders);

            var shoppingController = new ShoppingController(shoppingServiceMock.Object);

            var okResult = shoppingController.GetOrder() as OkObjectResult;
            var result = okResult.Value as List<OrderSummaryModel>;

            var resultOne = result.FirstOrDefault(x => x.Id == testOrder.Id);

            Assert.True(resultOne.Id == testOrder.Id);
            Assert.True(resultOne.AppleQuantity == testOrder.AppleQuantity);
            Assert.True(resultOne.OrangeQuantity == testOrder.OrangeQuantity);
            Assert.True(resultOne.TotalCost == testOrder.TotalCost);


            var resultTwo = result.FirstOrDefault(x => x.Id == testOrder2.Id);

            Assert.True(resultTwo.Id == testOrder2.Id);
            Assert.True(resultTwo.AppleQuantity == testOrder2.AppleQuantity);
            Assert.True(resultTwo.OrangeQuantity == testOrder2.OrangeQuantity);
            Assert.True(resultTwo.TotalCost == testOrder2.TotalCost);
        }
    }
}
