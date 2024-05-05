using System.Collections.Generic;

namespace FlightLogNet.Models
{
    using System;

    public class FlightTakeOffModel
    {
        public DateTime TakeoffTime { get; set; }

        public string Task { get; set; }

        public AirplaneWithCrewModel Towplane { get; set; }

        public IList<AirplaneWithCrewModel> Gliders { get; set; }
    }
}
