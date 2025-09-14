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
    internal class EventDeleterTest
    {
        [TestMethod]
        public void DeleteEvent()
        {
            // Arrange
            var context = new MxcHomeworkContext();
            var deleter = new EventDeleter(context);
            var e = new Event
            {
                Id = 1,
                Name = "Puskás Aréna",
                Location = "Budapest",
                Country = "Hungary",
                Capacity = 67155
            };

            // Act & Assert
            deleter.Delete(e);
        }
    }
}
