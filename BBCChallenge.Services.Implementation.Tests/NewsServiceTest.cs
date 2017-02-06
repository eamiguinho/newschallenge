using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BBCChallenge.Core.Interfaces;
using BBCChallenge.Core.Interfaces.DataServices;
using BBCChallenge.Core.Interfaces.Domain;
using BBCChallenge.Core.Interfaces.PlatformSpecific;
using BBCChallenge.Core.Interfaces.Services;
using BBCChallenge.Domain.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmCross.Platform;
using NSubstitute;

namespace BBCChallenge.Services.Implementation.Tests
{
    [TestClass]
    public class NewsServiceTest 
    {
        private IPlatformSpecificService _platformSpecific;
        private INewsLocalDataService _localDataService;
        private INewsOnlineDataService _onlineDataService;

        [TestInitialize]
        public void Init()
        {
            InitializeIoc.Init();
            IoCDomain.Register();
            _platformSpecific = Substitute.For<IPlatformSpecificService>();
            _onlineDataService = Substitute.For<INewsOnlineDataService>();
            _localDataService = Substitute.For<INewsLocalDataService>();
            Mvx.RegisterSingleton(_platformSpecific);
            Mvx.RegisterSingleton(_onlineDataService);
            Mvx.RegisterSingleton(_localDataService);
            IoCService.Register();
        }

        [TestMethod]
        public async Task NewsServiceTest_GetLatestNews_NoInternetConnection_NoSavedNews()
        {
            _platformSpecific.HasInternetConnection().Returns(false);
            _localDataService.GetSavedNews().Returns(null as List<INews>);
            var service = Mvx.Resolve<INewsService>();
            var res = await service.GetLatestNews();
            Assert.AreEqual(Result.NoInternetConnection, res.Result);
        }

        [TestMethod]
        public async Task NewsServiceTest_GetLatestNews_NoInternetConnection_SavedNews()
        {
            var news = Mvx.Resolve<INews>();
            news.Title = "test";
            news.Description = "test";
            var list = new List<INews>{news};
            _platformSpecific.HasInternetConnection().Returns(false);
            _localDataService.GetSavedNews().Returns(list);
            var service = Mvx.Resolve<INewsService>();
            var res = await service.GetLatestNews();
            Assert.AreEqual(Result.Ok, res.Result);
            Assert.IsTrue(res.Data.Count == 1);
        }

        [TestMethod]
        public async Task NewsServiceTest_GetLatestNews_ErrorFromServices_NoSavedNews()
        {
            _platformSpecific.HasInternetConnection().Returns(true);
            _localDataService.GetSavedNews().Returns(null as List<INews>);
            _onlineDataService.GetLatestNews(NewsType.Tech).Returns(new DataResult<List<INews>>(Result.Error));
            _onlineDataService.GetLatestNews(NewsType.UK).Returns(new DataResult<List<INews>>(Result.Error));
            var service = Mvx.Resolve<INewsService > ();
            var res = await service.GetLatestNews();
            Assert.AreEqual(Result.Error, res.Result);
        }

        [TestMethod]
        public async Task NewsServiceTest_GetLatestNews_ErrorFromServices_SavedNews()
        {
            var news = Mvx.Resolve<INews>();
            news.Title = "test";
            news.Description = "test";
            var list = new List<INews> { news };
            _platformSpecific.HasInternetConnection().Returns(true);
            _localDataService.GetSavedNews().Returns(null as List<INews>);
            _onlineDataService.GetLatestNews(NewsType.Tech).Returns(new DataResult<List<INews>>(list));
            _onlineDataService.GetLatestNews(NewsType.UK).Returns(new DataResult<List<INews>>(list));
            var service = Mvx.Resolve<INewsService>();
            var res = await service.GetLatestNews();
            Assert.AreEqual(Result.Ok, res.Result);
            Assert.IsTrue(res.Data.Count == 2);
        }
    }
}
