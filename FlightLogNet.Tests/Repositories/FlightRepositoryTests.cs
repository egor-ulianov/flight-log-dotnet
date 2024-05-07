namespace FlightLogNet.Tests.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using FlightLogNet.Models;
    using FlightLogNet.Repositories;
    using FlightLogNet.Repositories.Interfaces;

    using Xunit;

    using Microsoft.Extensions.Configuration;

    public class FlightRepositoryTests(IMapper mapper, IConfiguration configuration)
    {
        private IFlightRepository CreateFlightRepository()
        {
            return new FlightRepository(mapper, configuration);
        }

        private void RenewDatabase()
        {
            TestDatabaseGenerator.RenewDatabase(configuration);
        }

        [Fact]
        public void GetFlightsOfTypeGlider_Return2Gliders()
        {
            // Arrange
            this.RenewDatabase();
            var flightRepository = this.CreateFlightRepository();

            // Act
            var result = flightRepository
                .GetFlightsOfType(FlightType.Glider);


            // Assert
            Assert.True(result.Count == 2, "In test database is 2 gliders.");
        }

        [Fact]
        public void GetAirplanesInAir_ReturnFlightModels()
        {
            // Arrange
            this.RenewDatabase();
            var flightRepository = this.CreateFlightRepository();
            
            IList<FlightModel> result = flightRepository.GetAirplanesInAir();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetReport_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            this.RenewDatabase();
            var flightRepository = this.CreateFlightRepository();

            // Act
            var result = flightRepository.GetReport();
            
            // Assert
            Assert.True(result.Count == 3, "In test database is 3 flight starts");
            Assert.True(result[2].Gliders.Count == 0, "Last flight start should have null glider.");
        }
    }
}
