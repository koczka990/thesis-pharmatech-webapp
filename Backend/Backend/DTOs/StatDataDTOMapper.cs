using Backend.DLL.Models;

namespace Backend.DTOs
{
    public static class StatDataDTOMapper
    {
        public static StatDataDTO ToDTO(this StatData statData)
        {
            return new StatDataDTO(statData);
        }

        public static List<StatData> ToDTO(this List<StatData> statData)
        {
            var tmp = new List<StatData>();
            foreach (var item in statData)
            {
                tmp.Add(new StatDataDTO(item));
            }
            return tmp;
        }
    }
}
