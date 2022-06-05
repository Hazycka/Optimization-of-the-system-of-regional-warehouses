namespace VKR_WEB.Models
{
    public class Settings
    {
        public float MaxTemperature { get; set; }
        public float MinTemperature { get; set; }
        public float CostPerKm { get; set; }

        public Settings(float maxTemperature, float minTemperature, float costPerKm)
        {
            MaxTemperature = maxTemperature;
            MinTemperature = minTemperature;
            CostPerKm = costPerKm;
        }
    }
}
