using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MxcHomework.Data;
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
    public class EventModifyControllerTest
    {
        [TestMethod]
        public void ModifyEvent()
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

            var controller = new EventModifyController(mockContext.Object);
            var newEvent = new Event
            {
                Id = 0,
                Name = "EventD",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 400
            };

            // Act
            var result = controller.ModifyEvent(newEvent);

            // Assert
            // Event is found and valid, gets modified
            Assert.AreEqual("EventD", events[0].Name);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ModifyEventInvalid()
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

            var controller = new EventModifyController(mockContext.Object);
            var newEvent = new Event
            {
                Id = 0,
                Name = "",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 400
            };

            // Act
            var result = controller.ModifyEvent(newEvent);

            // Assert
            // Event is found with ID, but the request is invalid. No modification occurs, Bad Request returned
            Assert.AreNotEqual("EventD", events[0].Name);
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void ModifyEventNotFound()
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

            var controller = new EventModifyController(mockContext.Object);
            var newEvent = new Event
            {
                Id = 3,
                Name = "EventD",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 400
            };

            // Act
            var result = controller.ModifyEvent(newEvent);

            // Assert
            // Event not found, no modification occurs, Not Found returned
            Assert.AreNotEqual("EventD", events[0].Name);
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));
        }
    }
}
