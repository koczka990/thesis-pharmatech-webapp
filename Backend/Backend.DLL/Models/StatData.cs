using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DLL.Models
{
    public class StatData
    {
        public int StatDataId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public int HibaSum { get; set; }
        public int JoSum { get; set; }
        public int RepedtSum { get; set; }
        public int OlajosSum { get; set; }
        public int TorottszelSum { get; set; }

        public StatData()
        {
            Year = -1;
            Month = -1;
            Day = -1;
            FromTime = new DateTime(2022, 1, 1);
            ToTime = new DateTime(2050, 1, 1);
        }
        public StatData(int year, int month, int day)
        {
            Year = year;
            Month = month;
            Day = day;
            FromTime = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Utc);
            ToTime = new DateTime(year, month, day, 23, 59, 59, DateTimeKind.Utc);
            Reset();
        }

        public StatData(int year, int month)
        {
            Year = year;
            Month = month;
            Day = -1;
            FromTime = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc);
            ToTime = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc);
            ToTime = ToTime.AddMonths(1);
            ToTime = ToTime.AddSeconds(-1);
            Reset();
        }

        public StatData(int year)
        {
            Year = year;
            Month = -1;
            Day = -1;
            FromTime = new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            ToTime = new DateTime(year, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            ToTime = ToTime.AddYears(1);
            ToTime = ToTime.AddSeconds(-1);
            Reset();
        }

        public void Add(CountingData data)
        {
            JoSum += data.JoCount;
            RepedtSum += data.RepedtCount;
            OlajosSum += data.OlajosCount;
            TorottszelSum += data.TorottSzelCount;
            HibaSum = HibaSum + data.RepedtCount + data.OlajosCount + data.TorottSzelCount;
        }
        public void Add(List<CountingData> datas)
        {
            foreach(CountingData data in datas)
            {
                this.Add(data);
            }
        }

        public void Reset()
        {
            HibaSum = 0;
            JoSum = 0;
            RepedtSum = 0;
            OlajosSum = 0;
            TorottszelSum = 0;
        }

        public void CalcSum(List<CountingData> datas)
        {
            this.Reset();
            this.Add(datas);
        }
    }
}
