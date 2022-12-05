using Backend.DLL.Models;

namespace Backend.DTOs
{
    public static class CountingDataDTOMapper
    {
        public static CountingDataDTO ToDTO(this CountingData countingData)
        {
            return new CountingDataDTO(countingData);
        }

        public static List<CountingData> ToDTO(this List<CountingData> countingData)
        {
            var tmp = new List<CountingData>();
            foreach (var item in countingData)
            {
                tmp.Add(new CountingDataDTO(item));
            }
            return tmp;
        }
    }
}
