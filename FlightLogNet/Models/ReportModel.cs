using System.Collections.Generic;

namespace FlightLogNet.Models
{
    public class ReportModel
    {
        public FlightModel Towplane { get; set; }

        public IList<FlightModel> Gliders { get; set; }
    }
}
