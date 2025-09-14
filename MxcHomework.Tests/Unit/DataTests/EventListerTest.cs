using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;
using MxcHomework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MxcHomework.Tests.Unit.DataTests
{
    [TestClass]
    public class EventListerTest
    {
        [TestMethod]
        public void TestListEvents()
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
                Id = 0,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 0,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var lister = new EventLister(mockContext.Object);

            // Act
            var listedEvents = lister.ListEvents();

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual(3, listedEvents.Count);
        }

        [TestMethod]
        public void TestListEventsOrderByName()
        {
            // Arrange

            var event1 = new Event
            {
                Id = 0,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 100
            };
            var event2 = new Event
            {
                Id = 0,
                Name = "EventA",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 0,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var lister = new EventLister(mockContext.Object);

            // Act
            var listedEvents = lister.ListEvents("Name");

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual("EventA", listedEvents[0].Name);
        }

        [TestMethod]
        public void TestListEventsOrderByNameDescending()
        {
            // Arrange

            var event1 = new Event
            {
                Id = 0,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 100
            };
            var event2 = new Event
            {
                Id = 0,
                Name = "EventA",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 0,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var lister = new EventLister(mockContext.Object);

            // Act
            var listedEvents = lister.ListEvents("Name", false);

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual("EventC", listedEvents[0].Name);
        }

        [TestMethod]
        public void TestListEventsOrderByCapacity()
        {
            // Arrange

            var event1 = new Event
            {
                Id = 0,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 100
            };
            var event2 = new Event
            {
                Id = 0,
                Name = "EventA",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 0,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var lister = new EventLister(mockContext.Object);

            // Act
            var listedEvents = lister.ListEvents("Capacity");

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual("EventB", listedEvents[0].Name);
        }

        [TestMethod]
        public void TestListEventsOrderByCapacityDescending()
        {
            // Arrange

            var event1 = new Event
            {
                Id = 0,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 100
            };
            var event2 = new Event
            {
                Id = 0,
                Name = "EventA",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 0,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var lister = new EventLister(mockContext.Object);

            // Act
            var listedEvents = lister.ListEvents("Capacity", false);

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual("EventA", listedEvents[0].Name);
        }

        [TestMethod]
        public void TestListEventsPaged()
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
                Id = 0,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 0,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var lister = new EventLister(mockContext.Object);

            // Act
            var listedEvents = lister.ListEventsPaged(1);

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual(3, listedEvents.Count);
        }

        [TestMethod]
        public void TestListEventsPagedSize2()
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
                Id = 0,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 0,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var lister = new EventLister(mockContext.Object);

            // Act
            var listedEvents = lister.ListEventsPaged(2);

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual(2, listedEvents.Count);
            Assert.AreEqual(2, listedEvents[0].Count);
            Assert.AreEqual(1, listedEvents[1].Count);
        }

        [TestMethod]
        public void TestListEventsPagedOrdered()
        {
            // Arrange

            var event1 = new Event
            {
                Id = 0,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 100
            };
            var event2 = new Event
            {
                Id = 0,
                Name = "EventA",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 0,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var lister = new EventLister(mockContext.Object);

            // Act
            var listedEvents = lister.ListEventsPaged(1, "Name");

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual(3, listedEvents.Count);
            Assert.AreEqual("EventA", listedEvents[0][0].Name);
        }

        [TestMethod]
        public void TestListEventsPagedOrderedDescending()
        {
            // Arrange

            var event1 = new Event
            {
                Id = 0,
                Name = "EventB",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 100
            };
            var event2 = new Event
            {
                Id = 0,
                Name = "EventA",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 300
            };

            var event3 = new Event
            {
                Id = 0,
                Name = "EventC",
                Location = "TestLocation",
                Country = "TestCountry",
                Capacity = 200
            };

            var events = new List<Event> { event1, event2, event3 };
            var mockDbSet = Helper.GetQueryableMockDbSet(events);

            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var lister = new EventLister(mockContext.Object);

            // Act
            var listedEvents = lister.ListEventsPaged(1, "Name", false);

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual(3, listedEvents.Count);
            Assert.AreEqual("EventC", listedEvents[0][0].Name);
        }
    }
}
