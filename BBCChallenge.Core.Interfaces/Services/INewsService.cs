using System.Collections.Generic;
using System.Threading.Tasks;
using BBCChallenge.Core.Interfaces.Domain;

namespace BBCChallenge.Core.Interfaces.Services
{
    public interface INewsService
    {
        Task<DataResult<List<INews>>> GetLatestNews();
        void SetCurrent(INews model);
        INews GetCurrent();
    }
}
