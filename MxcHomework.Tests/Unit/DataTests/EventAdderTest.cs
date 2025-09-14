using Moq;
using MxcHomework.Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using MxcHomework.Data;
using MxcHomework.Database.Models;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MxcHomework.Tests.Unit.DataTests
{
    [TestClass]
    public class EventAdderTest
    {
        [TestMethod]
        public void TestEventAdder()
        {
            // Arrange

            var events = new List<Event>();
            var mockDbSet = Helper.GetQueryableMockDbSet(events);
            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var adder = new EventAdder(mockContext.Object);
            var e = new Event
            {
                Name = "Bebury Park",
                Location = "Alexandria",
                Country = "Egypt",
                Capacity = 7720
            };

            // Act
            adder.Add(e);

            // Assert
            // If the event is valid, event is added, and if no errors occured during adding, no exception is thrown
            mockDbSet.Verify(m => m.Add(It.IsAny<Event>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(EventValidatorException))]
        public void TestEventAdderInvalid()
        {
            // Arrange

            var events = new List<Event>();
            var mockDbSet = Helper.GetQueryableMockDbSet(events);
            var mockContext = new Mock<IMxcHomeworkContext>();
            mockContext.Setup(mock => mock.Events).Returns(() => mockDbSet.Object);

            var adder = new EventAdder(mockContext.Object);
            var e = new Event
            {
                Name = "",
                Location = "Alexandria",
                Country = "Egypt",
                Capacity = 7720
            };

            // Act
            adder.Add(e);

            // Assert
            // Invalid event, EventValidationException thrown, no event added.
            mockDbSet.Verify(m => m.Add(It.IsAny<Event>()), Times.Never);

        }
    }
}
