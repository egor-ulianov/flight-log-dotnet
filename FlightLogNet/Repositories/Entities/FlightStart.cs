﻿using System.Collections.Generic;

namespace FlightLogNet.Repositories.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class FlightStart
    {
        public long Id { get; set; }

        [Required]
        public Flight Towplane { get; set; }

        public IList<Flight> Gliders { get; set; }
    }
}
