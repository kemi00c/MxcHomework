using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MxcHomework.Data
{
    public class EventValidatorException : Exception
    {
        public EventValidatorException(string message) : base(message)
        {
        }
    }
}
