using Backend.DLL.Models;
using Backend.DLL.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services
{
    public class StatDataService : IStatDataService
    {
        private readonly IStatDataRepository statDataRepository;
        private readonly ICountingDataRepository countingDataRepository;

        public StatDataService(IStatDataRepository statDataRepository, ICountingDataRepository countingDataRepository)
        {
            this.statDataRepository = statDataRepository;
            this.countingDataRepository = countingDataRepository;
        }

        public void UpdateAll()
        {
            var from = countingDataRepository.GetOldest().FromTime;
            var to = countingDataRepository.GetNewest().ToTime;
            Calculate(from, to);
        }

        public void Calculate(DateTime fromTime, DateTime toTime)
        {
            var tmp = new DateTime(fromTime.Year, fromTime.Month, fromTime.Day, 0,0,0, DateTimeKind.Utc);
            while(tmp < toTime)
            {
                CalculateDay(tmp.Year, tmp.Month, tmp.Day);
                tmp = tmp.AddDays(1);
            }
            tmp = new DateTime(fromTime.Year, fromTime.Month, fromTime.Day, 0, 0, 0, DateTimeKind.Utc);
            while (tmp < toTime)
            {
                CalculateMonth(tmp.Year, tmp.Month);
                tmp = tmp.AddMonths(1);
            }
            tmp = new DateTime(fromTime.Year, fromTime.Month, fromTime.Day, 0, 0, 0, DateTimeKind.Utc);
            while (tmp < toTime)
            {
                CalculateYear(tmp.Year);
                tmp = tmp.AddYears(1);
            }
        }

        private void CalculateDay(int year, int month, int day)
        {
            var statRecord = statDataRepository.GetDay(year, month, day);
            var countingRecords = countingDataRepository.GetBetween(new DateTime(year, month, day, 0,0,0, DateTimeKind.Utc), new DateTime(year, month, day, 23,59,59, DateTimeKind.Utc));

            if (countingRecords == null || countingRecords.Count == 0) return;
            if (statRecord == null)//create new statData record
            {
                statRecord = new StatData(year, month, day);
                statRecord.CalcSum(countingRecords);
                statDataRepository.Create(statRecord);
            }
            else
            {
                statRecord.CalcSum(countingRecords);
                statDataRepository.Update(statRecord);
            }
            
        }

        private void CalculateMonth(int year, int month)
        {
            var statRecord = statDataRepository.GetMonth(year, month);
            var countingRecords = countingDataRepository.GetBetween(new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc), new DateTime(year, month, 1, 23, 59, 59, DateTimeKind.Utc).AddMonths(1).AddDays(-1));
            if (countingRecords == null || countingRecords.Count == 0) return;
            if (statRecord == null)//create new statData record
            {
                statRecord = new StatData(year, month);
                statRecord.CalcSum(countingRecords);
                statDataRepository.Create(statRecord);
            }
            else
            {
                statRecord.CalcSum(countingRecords);
                statDataRepository.Update(statRecord);
            }
        }

        private void CalculateYear(int year)
        {
            var statRecord = statDataRepository.GetYear(year);
            var countingRecords = countingDataRepository.GetBetween(new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Utc), new DateTime(year, 1, 1, 23, 59, 59, DateTimeKind.Utc).AddYears(1).AddDays(-1));
            if (countingRecords == null || countingRecords.Count == 0) return;
            if (statRecord == null)//create new statData record
            {
                statRecord = new StatData(year);
                statRecord.CalcSum(countingRecords);
                statDataRepository.Create(statRecord);
            }
            else
            {
                statRecord.CalcSum(countingRecords);
                statDataRepository.Update(statRecord);
            }
        }

        public StatData GetDay(int year, int month, int day)
        {
            return statDataRepository.GetDay(year, month, day);
        }

        public StatData GetMonth(int year, int month)
        {
            return statDataRepository.GetMonth(year, month);
        }

        public StatData GetYear(int year)
        {
            return statDataRepository.GetYear(year);
        }

        public List<StatData> GetDaysBetween(DateTime fromTime, DateTime toTime)
        {
            return statDataRepository.GetDaysBetween(fromTime, toTime);
        }

        public List<StatData> GetLastSeven()
        {
            return statDataRepository.GetLastSeven();
        }

        public List<StatData> GetMonthDays(int year, int month)
        {
            return statDataRepository.GetMonthDays(year, month);
        }

        public List<StatData> GetLastMonthDays()
        {
            return statDataRepository.GetLastMonthDays();
        }
    }
}
