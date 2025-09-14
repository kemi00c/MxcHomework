using Moq;
using MxcHomework.Data;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxcHomework.Tests.Unit
{
    [TestClass]
    public class EventModifierTest
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

            var modifier = new EventModifier(mockContext.Object);
            var newEvent = new Event
            {
                Id = 0,
                Name = "EventD",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 400
            };

            // Act
            modifier.Modify(newEvent);

            // Assert
            // Event is found and valid, gets modified
            Assert.AreEqual("EventD", events[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(EventValidatorException))]
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

            var modifier = new EventModifier(mockContext.Object);
            var newEvent = new Event
            {
                Id = 0,
                Name = "",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 400
            };

            // Act
            modifier.Modify(newEvent);

            // Assert
            // Event is found with ID, but the request is invalid. No modification occurs, EventValidatorException thrown
            Assert.AreNotEqual("EventD", events[0].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
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

            var modifier = new EventModifier(mockContext.Object);
            var newEvent = new Event
            {
                Id = 3,
                Name = "EventD",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 400
            };

            // Act
            modifier.Modify(newEvent);

            // Assert
            // Event not found, no modification occurs, ArgumentException thrown
            Assert.AreNotEqual("EventD", events[0].Name);
        }
    }
}
