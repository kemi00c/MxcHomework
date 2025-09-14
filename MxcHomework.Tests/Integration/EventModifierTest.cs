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
    public class EventModifierTest
    {
        [TestMethod]
        internal void ModifyEvent()
        {
            // Arrange
            var context = new MxcHomeworkContext();
            var modifier = new EventModifier(context);
            var e = new Event
            {
                Id = 1,
                Name = "Puskás Aréna",
                Location = "Budapest",
                Country = "Hungary",
                Capacity = 67155
            };

            // Act & Assert
            modifier.Modify(e);
        }
    }
}
