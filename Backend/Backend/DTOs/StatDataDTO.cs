using Backend.DLL.Models;

namespace Backend.DTOs
{
    public class StatDataDTO : StatData
    {
        public StatDataDTO(StatData statData)
        {
            StatDataId = statData.StatDataId;
            FromTime = statData.FromTime;
            ToTime = statData.ToTime;
            Year = statData.Year;
            Month = statData.Month;
            Day = statData.Day;
            JoSum = statData.JoSum;
            HibaSum = statData.HibaSum;
            RepedtSum = statData.RepedtSum;
            OlajosSum = statData.OlajosSum;
            TorottszelSum = statData.TorottszelSum;
        }
    }
}
