namespace TemperatureTask.Model
{
    internal class Scale
    {
        public double Difference { get; set; }

        public double Multiplier { get; set; }

        public Scale(double difference, double multiplier)
        {
            Difference = difference;
            Multiplier = multiplier;
        }
    }
}
