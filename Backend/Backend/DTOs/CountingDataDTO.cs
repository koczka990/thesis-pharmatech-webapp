using Backend.DLL.Models;

namespace Backend.DTOs
{
    public class CountingDataDTO : CountingData
    {
        public CountingDataDTO(CountingData countingData) 
        {
            CountingDataId = countingData.CountingDataId;
            FromTime = countingData.FromTime;
            ToTime = countingData.ToTime;
            TotalCount = countingData.TotalCount;
            JoCount = countingData.JoCount;
            RepedtCount = countingData.RepedtCount;
            OlajosCount = countingData.OlajosCount;
            TorottSzelCount = countingData.TorottSzelCount;
        }
    }
}
