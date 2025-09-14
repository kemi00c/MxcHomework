using Moq;
using MxcHomework.Data;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxcHomework.Tests.Unit.DataTests
{
    [TestClass]
    public class EventDeleterTest
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

            var deleter = new EventDeleter(mockContext.Object);
            var eventToDelete = new Event
            {
                Id = 0,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            // Act
            deleter.Delete(eventToDelete);

            // Assert
            // Event found and valid, it gets deleted
            mockDbSet.Verify(m => m.Remove(It.IsAny<Event>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(EventValidatorException))]
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

            var deleter = new EventDeleter(mockContext.Object);
            var eventToDelete = new Event
            {
                Id = 0,
                Name = "",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            // Act
            deleter.Delete(eventToDelete);

            // Assert
            // Event is invalid, validator fails with an EventValidatorException .
            mockDbSet.Verify(m => m.Remove(It.IsAny<Event>()), Times.Never);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
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

            var deleter = new EventDeleter(mockContext.Object);
            var eventToDelete = new Event
            {
                Id = 3,
                Name = "EventD",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            // Act
            deleter.Delete(eventToDelete);

            // Assert
            // Event to delete not found, ArgumentException is thrown.
            mockDbSet.Verify(m => m.Remove(It.IsAny<Event>()), Times.Never);
        }
    }
}
