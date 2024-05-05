namespace FlightLogNet.Repositories.Interfaces
{
    using System.Collections.Generic;

    using Models;

    public interface IFlightRepository
    {
        IList<ReportModel> GetReport();

        void LandFlight(FlightLandingModel landingModel);

        void TakeoffFlight(IList<long?> gliderFlightIds, long? towplaneFlightId);

        long CreateFlight(CreateFlightModel model);

        public IList<FlightModel> GetFlightsOfType(FlightType type);

        public IList<FlightModel> GetAirplanesInAir();

        IList<FlightModel> GetAllFlights();
    }
}
