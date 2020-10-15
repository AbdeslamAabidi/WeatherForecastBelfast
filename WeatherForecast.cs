using System;

namespace WeatheFrorecastBelfast
{
    public class Location
    {
        public string title { get; set; }
        public string location_type { get; set; }
        public string woeid { get; set; }
        public string latt_long { get; set; }
    }

    public class LocationDetails
    {
        public string id { get; set; }
        public string weather_state_name { get; set; }
        public string weather_state_abbr { get; set; }
        public string wind_direction_compass { get; set; }
        public string created { get; set; }
        public string applicable_date { get; set; }
        public string min_temp { get; set; }
        public string max_temp { get; set; }
        public string the_temp { get; set; }
        public string wind_speed { get; set; }
        public string wind_direction { get; set; }
        public string air_pressure { get; set; }
        public string humidity { get; set; }
        public string visibility { get; set; }
        public string predictability { get; set; }
    }
}
