using MxcHomework.Database.Data;
using MxcHomework.Database.Models;
using MxcHomework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxcHomework.Tests.Integration
{
    // The access modifier of this integration test class is set to internal to exclude it from CI/CD test runs. Change it to public to enable test discovery.
    [TestClass]
    internal class EventAdderTest
    {
        [TestMethod]
        public void TestAddEvent()
        {
            // Arrange
            var context = new MxcHomeworkContext();
            var adder = new EventAdder(context);
            var e = new Event
            {
                Name = "Bebury Park",
                Location = "Alexandria",
                Country = "Egypt",
                Capacity = 7720
            };

            // Act & Assert
            adder.Add(e);
        }
    }
}
