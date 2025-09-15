using Moq;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;
using MxcHomework.Data;

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
            var page1 = lister.ListEventsPaged(1, 0);
            var page2 = lister.ListEventsPaged(1, 1);
            var page3 = lister.ListEventsPaged(1, 2);

            bool outOfRangeExceptionThrown = false;

            try
            {
                lister.ListEventsPaged(1, 3);
            }
            catch (ArgumentOutOfRangeException)
            {
                outOfRangeExceptionThrown = true;
            }

            // Assert
            Assert.IsNotNull(page1);
            Assert.IsNotNull(page2);
            Assert.IsNotNull(page3);
            Assert.IsTrue(outOfRangeExceptionThrown);
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
            bool outOfRangeExceptionThrown = false;
            var page1 = lister.ListEventsPaged(2, 0);
            var page2 = lister.ListEventsPaged(2, 1);
            try
            {
                lister.ListEventsPaged(2, 2);
            }
            catch (ArgumentOutOfRangeException)
            {
                outOfRangeExceptionThrown = true;
            }

            // Assert
            Assert.IsNotNull(page1);
            Assert.IsNotNull(page2);
            Assert.IsTrue(outOfRangeExceptionThrown);
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
            bool outOfRangeExceptionThrown = false;
            var page1 = lister.ListEventsPaged(1, 0, "Name");
            var page2 = lister.ListEventsPaged(1, 1, "Name");
            var page3 = lister.ListEventsPaged(1, 2, "Name");

            try
            {
                var page4 = lister.ListEventsPaged(1, 3, "Name");
            }
            catch (ArgumentOutOfRangeException)
            {
                outOfRangeExceptionThrown = true;
            }

            // Assert
            Assert.IsNotNull(page1);
            Assert.IsNotNull(page2);
            Assert.IsNotNull(page3);
            Assert.IsTrue(outOfRangeExceptionThrown);
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

            var lister = new EventLister(mockContext.Object);

            // Act
            bool outOfRangeExceptionThrown = false;
            var page1 = lister.ListEventsPaged(1, 0, "Name", false);
            var page2 = lister.ListEventsPaged(1, 1, "Name", false);
            var page3 = lister.ListEventsPaged(1, 2, "Name", false);

            try
            {
                lister.ListEventsPaged(1, 3, "Name", false);
            }
            catch (ArgumentOutOfRangeException)
            {
                outOfRangeExceptionThrown = true;
            }

            // Assert
            Assert.IsNotNull(page1);
            Assert.IsNotNull(page2);
            Assert.IsNotNull(page3);
            Assert.IsTrue(outOfRangeExceptionThrown);
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

            var lister = new EventLister(mockContext.Object);

            // Act
            var pageCount = lister.GetPageCount(1);

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

            var lister = new EventLister(mockContext.Object);

            // Act
            var pageCount = lister.GetPageCount(2);

            // Assert
            Assert.AreEqual(2, pageCount);
        }
    }
}

