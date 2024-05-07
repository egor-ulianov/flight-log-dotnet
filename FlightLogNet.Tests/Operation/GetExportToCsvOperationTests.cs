using System.IO;

namespace FlightLogNet.Tests.Operation
{
    using FlightLogNet.Operation;

    using Xunit;

    public class GetExportToCsvOperationTests(GetExportToCsvOperation getExportToCsvOperation)
    {
        [Fact]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var expectedCsv = File.ReadAllBytes("export.csv");

            // Act
            var result = getExportToCsvOperation.Execute();
            string resultStr = System.Text.Encoding.Default.GetString(result);
            string expectedCsvStr = System.Text.Encoding.Default.GetString(expectedCsv);
            expectedCsvStr = expectedCsvStr.Replace("\r", null);

            // Assert
            Assert.Equal(expectedCsvStr.Length, resultStr.Length);
        }
    }
}
