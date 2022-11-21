using Backend.DLL.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services
{
    public class StatDataService : IStatDataService
    {
        private readonly IStatDataRepository statDataRepository;

        public StatDataService(IStatDataRepository statDataRepository)
        {
            this.statDataRepository = statDataRepository;
        }
    }
}
