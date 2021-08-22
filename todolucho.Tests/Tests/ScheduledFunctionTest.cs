using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using todolucho.Functions.Function;
using todolucho.Tests.Helpers;
using Xunit;

namespace todolucho.Tests.Tests
{
    public class ScheduledFunctionTest
    {
        [Fact]
        public void ScheduledFunction_Should_Log_Message()
        {
            //Arrange
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
           ListLogger logger = (ListLogger)TestFactory.CreateLogger(LoggerTypes.List);
            //Act
            ScheduleFunction.Run(null, mockTodos, logger);
            string message = logger.Logs[0];
            //Assert
            Assert.Contains("Deleting completed", message);
        }
    }
}
