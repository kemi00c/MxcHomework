using Microsoft.AspNetCore.Mvc;
using Moq;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;
using MxcHomework.Service.Controllers;

namespace MxcHomework.Tests.Unit.ControllerTests
{
    [TestClass]
    public class EventListControllerTest
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

            var controller = new EventListController(mockContext.Object);

            // Act
            var listedEvents = controller.ListEvents();

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual(3, listedEvents.Count);
        }

        [TestMethod]
        public void TestListEventsOrderedByName()
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

            var controller = new EventListController(mockContext.Object);

            // Act
            var listedEvents = controller.ListEventsOrdered("Name");

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual("EventA", listedEvents[0].Name);
        }

        [TestMethod]
        public void TestListEventsOrderedByNameDescending()
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

            var controller = new EventListController(mockContext.Object);

            // Act
            var listedEvents = controller.ListEventsOrdered("Name", false);

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual("EventC", listedEvents[0].Name);
        }

        [TestMethod]
        public void TestListEventsOrderedByCapacity()
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

            var controller = new EventListController(mockContext.Object);

            // Act
            var listedEvents = controller.ListEventsOrdered("Capacity");

            // Assert
            Assert.IsNotNull(listedEvents);
            Assert.AreEqual("EventB", listedEvents[0].Name);
        }

        [TestMethod]
        public void TestListEventsOrderedByCapacityDescending()
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

            var controller = new EventListController(mockContext.Object);

            // Act
            var listedEvents = controller.ListEventsOrdered("Capacity", false);

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

            var controller = new EventListController(mockContext.Object);

            // Act
            var page1 = controller.ListEventsPaged(1, 0).Value;
            var page2 = controller.ListEventsPaged(1, 1).Value;
            var page3 = controller.ListEventsPaged(1, 2).Value;
            var page4 = controller.ListEventsPaged(1, 3);

            // Assert
            Assert.IsNotNull(page1);
            Assert.IsNotNull(page2);
            Assert.IsNotNull(page3);
            Assert.IsInstanceOfType(page4, typeof(NotFoundObjectResult));
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

            var controller = new EventListController(mockContext.Object);

            // Act
            var page1 = (List<Event>?)controller.ListEventsPaged(2, 0).Value;
            var page2 = (List<Event>?)controller.ListEventsPaged(2, 1).Value;
            var page3 = controller.ListEventsPaged(2, 2);

            // Assert
            Assert.IsNotNull(page1);
            Assert.IsNotNull(page2);
            Assert.IsInstanceOfType(page3, typeof(NotFoundObjectResult));
            Assert.AreEqual(2, page1.Count);
            Assert.AreEqual(1, page2.Count);
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

            var controller = new EventListController(mockContext.Object);

            // Act
            var page1 = (List<Event>?)controller.ListEventsPagedOrdered(1, 0, "Name").Value;
            var page2 = (List<Event>?)controller.ListEventsPagedOrdered(1, 1, "Name").Value;
            var page3 = (List<Event>?)controller.ListEventsPagedOrdered(1, 2, "Name").Value;
            var page4 = controller.ListEventsPagedOrdered(1, 3, "Name");

            // Assert
            Assert.IsNotNull(page1);
            Assert.IsNotNull(page2);
            Assert.IsNotNull(page3);
            Assert.IsInstanceOfType(page4, typeof(NotFoundObjectResult));
            Assert.AreEqual("EventA", page1[0].Name);
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

            var controller = new EventListController(mockContext.Object);

            // Act
            var page1 = (List<Event>?)controller.ListEventsPagedOrdered(1, 0, "Name", false).Value;
            var page2 = (List<Event>?)controller.ListEventsPagedOrdered(1, 1, "Name", false).Value;
            var page3 = (List<Event>?)controller.ListEventsPagedOrdered(1, 2, "Name", false).Value;
            var page4 = controller.ListEventsPagedOrdered(1, 3, "Name", false);

            // Assert
            Assert.IsNotNull(page1);
            Assert.IsNotNull(page2);
            Assert.IsNotNull(page3);
            Assert.IsInstanceOfType(page4, typeof(NotFoundObjectResult));
            Assert.AreEqual("EventC", page1[0].Name);
        }

        [TestMethod]
        public void TestPageCount()
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

            var controller = new EventListController(mockContext.Object);

            // Act
            var pageCount = controller.GetPageCount(1);

            // Assert
            Assert.AreEqual(3, pageCount);
        }

        [TestMethod]
        public void TestPageCountForPageSize2()
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

            var controller = new EventListController(mockContext.Object);

            // Act
            var pageCount = controller.GetPageCount(2);

            // Assert
            Assert.AreEqual(2, pageCount);
        }
    }
}
