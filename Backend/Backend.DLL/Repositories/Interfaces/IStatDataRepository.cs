using Backend.DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DLL.Repositories.Interfaces
{
    public interface IStatDataRepository
    {
        public void Create(StatData countingData);
        public void Create(List<StatData> countingData);
        public StatData Get(int id);
        public List<StatData> GetAll();
        public List<StatData> GetBetween(DateTime fromTime, DateTime toTime);
        public StatData GetDay(int year, int month, int day);
        public StatData GetMonth(int year, int month);
        public StatData GetYear(int year);
        public void Update(StatData statData);
        List<StatData> GetDaysBetween(DateTime fromTime, DateTime toTime);
        public List<StatData> GetLastSeven();
    }
}
