using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBCChallenge.Core.Interfaces.Domain;

namespace BBCChallenge.Core.Interfaces.DataServices
{
    public interface INewsLocalDataService
    {
        Task SaveLatestNews(List<INews> list);
        Task<List<INews>> GetSavedNews();
    }
}
