using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using ArtOfTest.Common.Exceptions;
using AuScGen;
using Framework;

namespace AuScGen
{
    /// <summary>
    /// This Exception Class handles the exceptions related to Telerik and Browser
    /// </summary>
    public class GUIException : TCDFrameworkException
    {

        enum ErrorType
        {
            NullReferenceException,

        };

        enum MethodName
        {
            GetHtmlControl,
            TestFixture,
            WaitForControl
        };
        /// <summary>
        /// The logger
        /// </summary>
        private static log4net.ILog Logger =
                   log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()
                   .DeclaringType);
        /// <summary>
        /// Initializes a new instance of the <see cref="TCDFrameworkException" /> class.
        /// </summary>
        /// <param name="e"></param>
        public GUIException(Exception innerException)
            : base(innerException)
        {
            Logger.Debug("Inside GUIException Class");

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TCDFrameworkException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <exception cref="ArtOfTest.Common.Exceptions.FindElementException">Failed to find the Element on the screen!</exception>
        public GUIException(string message)
            : base()
        {
            if (message.Contains("Element not found"))
            {
                Logger.Error("Failed to find the Element on the screen!!");
                throw new FindElementException("Failed to find the Element on the screen!");
            }
            else
            {
                Logger.Error(message);
            }

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GUIException" /> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="message">The message.</param>
        /// <exception cref="ArtOfTest.Common.Exceptions.FindElementException"></exception>
        public GUIException(string element, string message)
            : base()
        {
            if (message.Contains("Element not found"))
            {
                Logger.Error(string.Concat("Failed to find the Element With Logical Name [", element, "] on the screen!!"));
                string exceptionMessage = string.Concat("Failed to find the Element with Logical Name",
                    "[", element, "] on the screen!");
                throw new FindElementException(exceptionMessage);
            }

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="TCDFrameworkException" /> class.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="innerException">The exception that is the cause of the current
        /// exception, or a null reference (Nothing in Visual Basic) if no inner
        /// exception is specified.</param>
        /// <exception cref="System.TimeoutException">
        /// </exception>
        public GUIException(string element, Exception innerException)
            : base(innerException)
        {
            //Get the method from where the exception occured and decide the type exception to be thrown
            string exceptionString = innerException.GetType().ToString();
            string methodName = innerException.TargetSite.Name;
            string exceptionMessage = "";
            string messageType = innerException.GetType().Name;
            switch (innerException.GetType().Name)
            {
                case "NullReferenceException":
                    switch (methodName)
                    {
                        case "TestFixture":
                            exceptionMessage = string.Concat("Seems Browser Timed Out or",
                                                "Closed and hence the Element [", element, " is not Found!");
                            Logger.Error(string.Concat(exceptionString + exceptionMessage));
                            throw new TimeoutException(exceptionString + exceptionMessage);
                        case "WaitForControl":
                            exceptionMessage = string.Concat("Failed to Find the Element with Logical Name [",
                            element, " On the Screen");
                            Logger.Error(exceptionString + exceptionMessage);
                            throw new TimeoutException(exceptionString + exceptionMessage);
                        case "GetHtmlControl":
                            exceptionMessage = string.Concat("Seems Browser Timed Out or",
                                               "Closed and hence the Element [", element, "] is not Found!");
                            Logger.Error(string.Concat(exceptionString + exceptionMessage));
                            throw new TimeoutException(exceptionString + exceptionMessage);
                    }
                    break;
                case "ArgumentOutOfRangeException":
                    switch (methodName)
                    {
                        case "InternalSubStringWithChecks":
                            exceptionMessage = "User has not specified the GUI Map file in the Page. Please Check the GUI file Name!";
                            Logger.Error(exceptionMessage);
                            throw new ArgumentOutOfRangeException(exceptionMessage,innerException.StackTrace);
                  }
                    break;
            }

        }
    }
      

}
