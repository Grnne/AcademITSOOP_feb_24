namespace TemperatureTask.Model
{
    internal class Scale
    {
        public double Delta { get; set; }

        public double Modifier { get; set; }

        public Scale(double delta, double modifier)
        {
            Delta = delta;
            Modifier = modifier;
        }
    }
}
