namespace TemperatureTask.Model
{
    public interface IConverter
    {
        double Convert(double sourceTemperature, int sourceTemperatureScale, int resultTemperatureScale);
    }
}