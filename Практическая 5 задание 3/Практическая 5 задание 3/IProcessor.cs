namespace Практическая_5_задание_3
{
    public interface IProcessor
    {
        int Cores { get; set; }
        int Threads { get; set; }
        decimal ClockSpeed { get; set; }
    }
}