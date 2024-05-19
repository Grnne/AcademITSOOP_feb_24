namespace TemperatureTask.Model.Scales
{
    public interface IScale
    {
        string GetName();

        double ConvertFromCelsius(double celsiusTemperature);

        double ConvertToCelsius(double sourceTemperature);
    }
}