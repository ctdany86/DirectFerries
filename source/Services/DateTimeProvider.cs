namespace DirectFerriesWebApp.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime DateTimeNow => DateTime.Now;
    }
}
