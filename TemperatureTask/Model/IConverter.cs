namespace TemperatureTask.Model
{
    public interface IConverter
    {
        double ConvertFromCelsius(int resultTemperatureScale);

        void ConvertToCelsius(double sourceTemperature, int sourceTemperatureScale);

        double Convert(double sourceTemperature, int sourceTemperatureScale, int resultTemperatureScale);
    }
}