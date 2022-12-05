using Backend.DLL.Models;

namespace Backend.Services.Interfaces
{
    public interface IStatDataService
    {
        void UpdateAll();
        StatData GetDay(int year, int month, int day);
        StatData GetMonth(int year, int month);
        StatData GetYear(int year);
        List<StatData> GetDaysBetween(DateTime fromTime, DateTime toTime);
        public List<StatData> GetLastSeven();
        public List<StatData> GetMonthDays(int year, int month);
        public List<StatData> GetLastMonthDays();
    }
}
