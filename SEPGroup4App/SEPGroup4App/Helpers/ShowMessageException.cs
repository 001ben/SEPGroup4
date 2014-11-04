using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEPGroup4App.Helpers
{
    public class ShowMessageException : Exception
    {
        public ShowMessageException(string message)
            : base(message)
        { }

        public ShowMessageException(string message, params string[] formatArgs)
            : base(string.Format(message, formatArgs))
        { }
    }
}