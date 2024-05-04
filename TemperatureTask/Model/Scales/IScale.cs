namespace TemperatureTask.Model.Scales
{
    public interface IScale
    {
        double ConvertFromCelsius(int resultTemperatureScale);

        void ConvertToCelsius(double sourceTemperature, int sourceTemperatureScale);
    }
}