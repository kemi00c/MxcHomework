using MxcHomework.Data;
using MxcHomework.Database.Data;
using MxcHomework.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxcHomework.Tests.Integration
{
    // The access modifier of this integration test class is set to internal to exclude it from CI/CD test runs. Change it to public to enable test discovery.
    [TestClass]
    internal class EventListerTest
    {
        [TestMethod]
        public void ListEvents()
        {
            // Arrange
            var context = new MxcHomeworkContext();
            var lister = new EventLister(context);

            // Act
            var events = lister.ListEvents();

            // Assert
            Assert.IsInstanceOfType(events, typeof(List<Event>));
        }

        [TestMethod]
        public void ListEventsOrdered()
        {
            // Arrange
            var context = new MxcHomeworkContext();
            var lister = new EventLister(context);

            // Act
            var events = lister.ListEvents("Name");

            // Assert
            Assert.IsInstanceOfType(events, typeof(List<Event>));
        }
    }
}
