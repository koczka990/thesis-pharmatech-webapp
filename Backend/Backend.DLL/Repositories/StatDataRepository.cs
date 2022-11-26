using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DLL.Context;
using Backend.DLL.Models;
using Backend.DLL.Repositories.Interfaces;

namespace Backend.DLL.Repositories
{
    public class StatDataRepository : IStatDataRepository
    {
        private DataContext dataContext { get; set; }

        public StatDataRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Create(StatData statData)
        {
            dataContext.statDatas.Add(statData);
            dataContext.SaveChanges();
        }

        public void Create(List<StatData> statData)
        {
            foreach (var data in statData)
            {
                dataContext.statDatas.Add(data);
            }
            dataContext.SaveChanges();
        }

        public StatData Get(int id)
        {
            return dataContext.statDatas.FirstOrDefault(x => x.StatDataId == id);
        }
        public List<StatData> GetAll()
        {
            var q = from m in dataContext.statDatas select m;
            return q.ToList();
        }

        public List<StatData> GetBetween(DateTime fromTime, DateTime toTime)
        {
            var q = from m in dataContext.statDatas
                    where m.FromTime >= fromTime && m.ToTime <= toTime
                    select m;
            return q.ToList();
        }

        public StatData GetDay(int year, int month, int day)
        {
            return dataContext.statDatas.FirstOrDefault(x => x.Year == year && x.Month == month && x.Day == day);
        }
        public StatData GetMonth(int year, int month)
        {
            return dataContext.statDatas.FirstOrDefault(x => x.Year == year && x.Month == month && x.Day == -1);
        }

        public StatData GetYear(int year)
        {
            return dataContext.statDatas.FirstOrDefault(x => x.Year == year && x.Month == -1 && x.Day == -1);
        }

        public void Update(StatData statData)
        {
            var data = Get(statData.StatDataId);
            if (data == null) return;
            dataContext.Update(statData);
            dataContext.SaveChanges();
        }
    }
}
