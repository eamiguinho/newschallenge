using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBCChallenge.Core.Interfaces;
using BBCChallenge.Core.Interfaces.DataServices;
using BBCChallenge.Core.Interfaces.Domain;
using BBCChallenge.Core.Interfaces.PlatformSpecific;
using BBCChallenge.Core.Interfaces.Services;

namespace BBCChallenge.Services.Implementation
{
    public class NewsService : INewsService
    {
        private readonly INewsLocalDataService _localDataService;
        private readonly INewsOnlineDataService _onlineDataService;
        private readonly IPlatformSpecificService _platformSpecificService;
        private INews _current;

        public NewsService(INewsLocalDataService localDataService, INewsOnlineDataService onlineDataService, IPlatformSpecificService platformSpecificService)
        {
            _localDataService = localDataService;
            _onlineDataService = onlineDataService;
            _platformSpecificService = platformSpecificService;
        }

        public async Task<DataResult<List<INews>>> GetLatestNews()
        {
            var localSaved = await _localDataService.GetSavedNews();
            if (!_platformSpecificService.HasInternetConnection())
            {
                if (localSaved == null) return new DataResult<List<INews>>(Result.NoInternetConnection);
                return new DataResult<List<INews>>(localSaved);
            }
            var resUk = await _onlineDataService.GetLatestNews(NewsType.UK);
            var resTech = await _onlineDataService.GetLatestNews(NewsType.Tech);
            if (resTech.IsOk && resUk.IsOk)
            {
                var list = new List<INews>();
                list.AddRange(resUk.Data);
                list.AddRange(resTech.Data);
                await _localDataService.SaveLatestNews(list);
                return new DataResult<List<INews>>(list.OrderByDescending(x => x.Date).ToList());
            }
            if (localSaved == null) return new DataResult<List<INews>>(Result.Error);
            return new DataResult<List<INews>>(localSaved);
        }

        public void SetCurrent(INews news)
        {
            _current = news;
        }

        public INews GetCurrent()
        {
            return _current;
        }
    }
}
