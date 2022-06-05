using System.Text.Json.Serialization;

namespace VKR_WEB.Models
{
    public class RouteService
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonIgnore]
        public List<Waypoint> Waypoints { get; set; }

        [JsonPropertyName("routes")]
        public List<Route> Routes { get; set; }
    }

    public class Route
    {
        [JsonPropertyName("distance")]
        public float Distance { get; set; }

        [JsonPropertyName("duration")]
        public float Duration { get; set; }

        [JsonPropertyName("weight")]
        public float Weight { get; set; }

        [JsonPropertyName("weight_name")]
        public string Weight_Name { get; set; }

        [JsonPropertyName("geometry")]
        public string Geometry { get; set; }

        [JsonPropertyName("legs")]
        public List<Leg> Legs { get; set; }
    }

    public class Geometry
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("coordinates")]
        public List<List<float>> Coordinates { get; set; }
    }

    public class Leg
    {
        [JsonPropertyName("distance")]
        public float Distance { get; set; }
        [JsonPropertyName("duration")]
        public float Duration { get; set; }

        [JsonIgnore]
        public List<RouteStep> Steps { get; set; }
    }

    public class Waypoint
    {

    }

    public class RouteStep
    {

    }
}
