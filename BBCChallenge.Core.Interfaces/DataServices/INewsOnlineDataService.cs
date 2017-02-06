using System.Collections.Generic;
using System.Threading.Tasks;
using BBCChallenge.Core.Interfaces.Domain;

namespace BBCChallenge.Core.Interfaces.DataServices
{
    public interface INewsOnlineDataService
    {
        Task<DataResult<List<INews>>> GetLatestNews(NewsType type);
    }
}