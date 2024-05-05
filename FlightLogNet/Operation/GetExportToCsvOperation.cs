using System.Collections.Generic;
using System.Text;
using FlightLogNet.Models;

namespace FlightLogNet.Operation
{
    using Repositories.Interfaces;

    public class GetExportToCsvOperation(IFlightRepository flightRepository)
    {
        public byte[] Execute()
        {
            var flightData = GetFlightData();
            var csvContent = CreateCsvContent(flightData);
            return Encoding.UTF8.GetBytes(csvContent);
        }

        private IList<ReportModel> GetFlightData()
        {
            return flightRepository.GetReport();
        }

        private string CreateCsvHeader()
        {
            return "FlightId,TakeoffTime,LandingTime,Immatriculation,PilotId,PilotFirstName,PilotLastName,CopilotId,CopilotFirstName,CopilotLastName,Task";
        }

        private string CreateFlightRow(ReportModel flight)
        {
            string towplaneCopilotMemberId = flight.Towplane.Copilot != null ? flight.Towplane.Copilot.MemberId.ToString() : string.Empty;
            string towplaneCopilotFirstName = flight.Towplane.Copilot != null ? flight.Towplane.Copilot.FirstName : string.Empty;
            string towplaneCopilotLastName = flight.Towplane.Copilot != null ? flight.Towplane.Copilot.LastName : string.Empty;

            string row = $"{flight.Towplane.Id}," +
                         $"{flight.Towplane.TakeoffTime}," +
                         $"{flight.Towplane.LandingTime}," +
                         $"{flight.Towplane.Airplane.Immatriculation}," +
                         $"{flight.Towplane.Pilot.MemberId}," +
                         $"{flight.Towplane.Pilot.FirstName}," +
                         $"{flight.Towplane.Pilot.LastName}," +
                         $"{towplaneCopilotMemberId}," +
                         $"{towplaneCopilotFirstName}," +
                         $"{towplaneCopilotLastName}," +
                         $"{flight.Towplane.Task}";

            if (flight.Gliders != null)
            {
                foreach (var glider in flight.Gliders)
                {
                    string gliderCopilotMemberId = glider.Copilot != null ? glider.Copilot.MemberId.ToString() : string.Empty;
                                    string gliderCopilotFirstName = glider.Copilot != null ? glider.Copilot.FirstName : string.Empty;
                                    string gliderCopilotLastName = glider.Copilot != null ? glider.Copilot.LastName : string.Empty;
                    
                                    row += $"\n{glider.Id}," +
                                           $"{glider.TakeoffTime}," +
                                           $"{glider.LandingTime}," +
                                           $"{glider.Airplane.Immatriculation}," +
                                           $"{glider.Pilot.MemberId}," +
                                           $"{glider.Pilot.FirstName}," +
                                           $"{glider.Pilot.LastName}," +
                                           $"{gliderCopilotMemberId}," +
                                           $"{gliderCopilotFirstName}," +
                                           $"{gliderCopilotLastName}," +
                                           $"{glider.Task}";
                }
                
            }

            return row;
        }

        private string CreateCsvContent(IList<ReportModel> flightData)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(CreateCsvHeader());

            foreach (var flight in flightData)
            {
                var row = CreateFlightRow(flight);
                builder.AppendLine(row);
            }

            return builder.ToString();
        }
    }
}
