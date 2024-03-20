using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SortedExam.Api.Controllers;
using SortedExam.Model.App.Exceptions;
using SortedExam.Model.App.Locals;
using SortedExam.Model.App.Responses;
using SortedExam.Service.Interfaces;

namespace SortedExam.Test.MockTests
{
    [TestClass]
    public class RainfallControllerMockTest
    {
        private RainfallController _controller;
        private Mock<IRainfallService> _rainfallServiceMock;

        [TestInitialize]
        public void Setup()
        {
            _rainfallServiceMock = new Mock<IRainfallService>();
            _controller = new RainfallController(_rainfallServiceMock.Object);
        }

        [TestMethod]
        public async Task GetAllStationReadingAsync_ValidInput_ReturnsOk()
        {
            // Arrange
            var stationId = "TEST123";
            var count = 10;
            var datetimeUTC = DateTime.UtcNow;
            var rainfallReading = new RainfallReading(datetimeUTC, 1.0m);
            var expectedResponse = new RainfallReadingResponse(new List<RainfallReading> { rainfallReading });
            _rainfallServiceMock
                .Setup(service => service.GetStationReadingAsync(stationId, count))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetAllStationReadingAsync(stationId, count);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var okResult = (OkObjectResult)result;
            Assert.AreEqual(expectedResponse, okResult.Value);
        }

        [TestMethod]
        public async Task GetAllStationReadingAsync_ValidInput_ReturnsNotFound()
        {
            // Arrange
            var stationId = "TEST123";
            var count = 10;
            var expectedErrorMessage = "No records found";

            _rainfallServiceMock
                 .Setup(service => service.GetStationReadingAsync(stationId, count))
                 .ThrowsAsync(new NoRecordFoundException(expectedErrorMessage));

            // Act
            var result = await _controller.GetAllStationReadingAsync(stationId, count);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
            var notFoundResult = (NotFoundObjectResult)result;
            var errorResponse = notFoundResult.Value as ErrorResponse;
            Assert.AreEqual(expectedErrorMessage, errorResponse?.Message);
        }

        [TestMethod]
        public async Task GetAllStationReadingAsync_ValidInput_ReturnsInternalServerError()
        {
            // Arrange
            var stationId = "TEST123";
            var count = 10;
            var expectedErrorMessage = "Internal Server Error";

            _rainfallServiceMock
                 .Setup(service => service.GetStationReadingAsync(stationId, count))
                 .ThrowsAsync(new Exception(expectedErrorMessage));

            // Act
            var result = await _controller.GetAllStationReadingAsync(stationId, count);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ObjectResult));
            var objectCodeResult = (ObjectResult)result;
            Assert.AreEqual(500, objectCodeResult.StatusCode);
            var errorResponse = objectCodeResult.Value as ErrorResponse;
            Assert.AreEqual(expectedErrorMessage, errorResponse?.Message);
        }
    }
}
