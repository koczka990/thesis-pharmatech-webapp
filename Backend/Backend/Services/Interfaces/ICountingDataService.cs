using Backend.DLL.Models;

namespace Backend.Services.Interfaces
{
    public interface ICountingDataService
    {
        public void GenerateTestData(DateTime fromTime, DateTime toTime);
        public List<CountingData> GetAllData();
    }
}
