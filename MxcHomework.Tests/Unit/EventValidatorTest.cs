using MxcHomework.Data;
using MxcHomework.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxcHomework.Tests.Unit
{
    [TestClass]
    public class EventValidatorTest
    {
        [TestMethod]
        public void TestEventValidator()
        {
            // Arrange
            var e = new Event
            {
                Id = 0,
                Name = "Bebury Park",
                Location = "Alexandria",
                Country = "Egypt",
                Capacity = 7720
            };
            var validator = new EventValidator(e);

            // Act & Assert
            validator.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(EventValidatorException), "Mandatory field, Name is empty.")]
        public void TestEventValidatorWithNameEmpty()
        {
            // Arrange
            var e = new Event
            {
                Id = 0,
                Name = "",
                Location = "Alexandria",
                Country = "Egypt",
                Capacity = 7720
            };
            var validator = new EventValidator(e);

            // Act & Assert
            validator.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(EventValidatorException), "Mandatory field, Location is empty.")]
        public void TestEventValidatorWithLocationEmpty()
        {
            // Arrange
            var e = new Event
            {
                Id = 0,
                Name = "Bebury Park",
                Location = "",
                Country = "Egypt",
                Capacity = 7720
            };
            var validator = new EventValidator(e);

            // Act & Assert
            validator.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(EventValidatorException), "Location field is longer than the maximum allowed 100 characters.")]
        public void TestEventValidatorWithLocationTooLong()
        {
            // Arrange
            var e = new Event
            {
                Id = 0,
                Name = "Bebury Park",
                Location = "LongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLongLocation",
                Country = "Egypt",
                Capacity = 7720
            };
            var validator = new EventValidator(e);

            // Act & Assert
            validator.Validate();
        }

        [TestMethod]
        public void TestEventValidatorWithEmptyCountry()
        {
            // Arrange
            var e = new Event
            {
                Id = 0,
                Name = "Bebury Park",
                Location = "Alexandria",
                Country = "",
                Capacity = 7720
            };
            var validator = new EventValidator(e);

            // Act & Assert
            validator.Validate();
        }

        [TestMethod]
        public void TestEventValidatorWithNullCountry()
        {
            // Arrange
            var e = new Event
            {
                Id = 0,
                Name = "Bebury Park",
                Location = "Alexandria",
                Country = null,
                Capacity = 7720
            };
            var validator = new EventValidator(e);

            // Act & Assert
            validator.Validate();
        }

        [TestMethod]
        public void TestEventValidatorWithNullCapacity()
        {
            // Arrange
            var e = new Event
            {
                Id = 0,
                Name = "Bebury Park",
                Location = "Alexandria",
                Country = "Egypt",
                Capacity = null
            };
            var validator = new EventValidator(e);

            // Act & Assert
            validator.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(EventValidatorException), "Capacity should be a positive value.")]
        public void TestEventValidatorWithZeroCapacity()
        {
            // Arrange
            var e = new Event
            {
                Id = 0,
                Name = "Bebury Park",
                Location = "Alexandria",
                Country = "Egypt",
                Capacity = 0
            };
            var validator = new EventValidator(e);

            // Act & Assert
            validator.Validate();
        }

        [TestMethod]
        [ExpectedException(typeof(EventValidatorException), "Capacity should be a positive value.")]
        public void TestEventValidatorWithNegativeCapacity()
        {
            // Arrange
            var e = new Event
            {
                Id = 0,
                Name = "Bebury Park",
                Location = "Alexandria",
                Country = "Egypt",
                Capacity = -1
            };
            var validator = new EventValidator(e);

            // Act & Assert
            validator.Validate();
        }
    }
}
