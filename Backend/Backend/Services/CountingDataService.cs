using Backend.Services.Interfaces;
using Backend.DLL.Models;
using Backend.DLL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Services
{
    public class CountingDataService : ICountingDataService
    {
        private readonly ICountingDataRepository countingDataRepository;
        private readonly IStatDataService statDataService;
        public CountingDataService(ICountingDataRepository repository, IStatDataService statDataService)
        {
            this.countingDataRepository = repository;
            this.statDataService = statDataService;
        }
        public void GenerateTestData([FromQuery]DateTime fromTime, [FromQuery]DateTime toTime)
        {
            List<CountingData> list = new List<CountingData>();
            int startHour = 6;
            int finishHour = 18;
            var rnd = new Random();
            foreach(var day in EachDay(fromTime, toTime))
            {
                var start = new DateTime(day.AddHours(startHour).Ticks, DateTimeKind.Utc);
                var finish = new DateTime(day.AddHours(finishHour).Ticks, DateTimeKind.Utc);
                while(start < finish)
                {
                    int minuteOffset = rnd.Next(2, 8);
                    var countingData = new CountingData()
                    {
                        FromTime = start,
                        ToTime = start.AddMinutes(minuteOffset),
                        JoCount = rnd.Next(100) * rnd.Next(1,3),
                        RepedtCount = rnd.Next(100),
                        OlajosCount = rnd.Next(100),
                        TorottSzelCount = rnd.Next(100),
                    };
                    countingData.calcTotal();
                    start = start.AddMinutes(minuteOffset);
                    list.Add(countingData);
                }
            }
            countingDataRepository.Create(list);
        }

        public List<CountingData> GetAllData()
        {
            return countingDataRepository.GetAll();
        }

        private IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        public void Create(CountingData countingData)
        {
            countingDataRepository.Create(countingData);
            statDataService.Update(countingData);
        }
    }
}
