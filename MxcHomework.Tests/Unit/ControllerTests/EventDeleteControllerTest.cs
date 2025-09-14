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
    public class EventDeleteControllerTest
    {
        [TestMethod]
        public void DeleteEvent()
        {
            // Arrange

            var event1 = new Event
            {
                Id = 0,
                Name = "EventA",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 100
            };
            var event2 = new Event
            {
                Id = 1,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 2,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var controller = new EventDeleteController(mockContext.Object);
            var eventToDelete = new Event
            {
                Id = 0,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            // Act
            var result = controller.DeleteEvent(eventToDelete);

            // Assert
            // Event found and valid, it gets deleted
            mockDbSet.Verify(m => m.Remove(It.IsAny<Event>()), Times.Once);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DeleteEventInvalid()
        {
            // Arrange

            var event1 = new Event
            {
                Id = 0,
                Name = "EventA",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 100
            };
            var event2 = new Event
            {
                Id = 1,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 2,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var controller = new EventDeleteController(mockContext.Object);
            var eventToDelete = new Event
            {
                Id = 0,
                Name = "",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            // Act
            var result = controller.DeleteEvent(eventToDelete);

            // Assert
            // Event is invalid, Bad Request returned.
            mockDbSet.Verify(m => m.Remove(It.IsAny<Event>()), Times.Never);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void DeleteEventNotFound()
        {
            // Arrange

            var event1 = new Event
            {
                Id = 0,
                Name = "EventA",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 100
            };
            var event2 = new Event
            {
                Id = 1,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 2,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var controller = new EventDeleteController(mockContext.Object);
            var eventToDelete = new Event
            {
                Id = 3,
                Name = "EventD",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            // Act
            var result = controller.DeleteEvent(eventToDelete);

            // Assert
            // Event to delete not found, Not Found returned.
            mockDbSet.Verify(m => m.Remove(It.IsAny<Event>()), Times.Never);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}
