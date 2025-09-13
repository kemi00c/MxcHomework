using MxcHomework.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxcHomework.Data
{
    public class EventValidator
    {
        private readonly Event _event;

        public EventValidator(Event e)
        {
            _event = e;
        }

        /// <summary>
        /// Validates an event based on the following principles:
        /// - Name must not be empty
        /// - Location must not be empty
        /// - Location must not be longer than 100 characters
        /// - Capacity if present, must be a positive number
        /// If the validation fails, an EventValidationException is thrown.
        /// </summary>
        /// <exception cref="EventValidatorException"></exception>
        public void Validate()
        {
            if (string.IsNullOrEmpty(_event.Name))
            {
                throw new EventValidatorException("Mandatory field, Name is empty.");
            }

            if (string.IsNullOrEmpty(_event.Location))
            {
                throw new EventValidatorException("Mandatory field, Location is empty");
            }

            if (_event.Location.Length >= 100)
            {
                throw new EventValidatorException("Location field is longer than the maximum allowed 100 characters.");
            }

            if (_event.Capacity != null && _event.Capacity <= 0)
            {
                throw new EventValidatorException("Capacity should be a positive value.");
            }
        }
    }
}
