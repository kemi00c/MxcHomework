using Microsoft.AspNetCore.Mvc;
using Moq;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;
using MxcHomework.Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxcHomework.Tests.Unit.ControllerTests
{
    [TestClass]
    public class EventAddControllerTest
    {
        [TestMethod]
        public void TestEventAdder()
        {
            // Arrange

            var events = new List<Event>();
            var mockDbSet = Helper.GetQueryableMockDbSet(events);
            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var controller = new EventAddController(mockContext.Object);
            var e = new Event
            {
                Name = "Bebury Park",
                Location = "Alexandria",
                Country = "Egypt",
                Capacity = 7720
            };

            // Act
            var result = controller.AddEvent(e);

            // Assert
            // If the event is valid, event is added, and if no errors occured during adding, no exception is thrown
            mockDbSet.Verify(m => m.Add(It.IsAny<Event>()), Times.Once);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void TestEventAdderInvalid()
        {
            // Arrange

            var events = new List<Event>();
            var mockDbSet = Helper.GetQueryableMockDbSet(events);
            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var controller = new EventAddController(mockContext.Object);
            var e = new Event
            {
                Name = "",
                Location = "Alexandria",
                Country = "Egypt",
                Capacity = 7720
            };

            // Act
            var result = controller.AddEvent(e);

            // Assert
            // Invalid event, Bad Request returned, no event added.
            mockDbSet.Verify(m => m.Add(It.IsAny<Event>()), Times.Never);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }
    }
}
