using System;
using System.Threading.Tasks;
using BBCChallenge.Core.Interfaces;
using BBCChallenge.Core.Interfaces.DataServices;
using BBCChallenge.Core.Interfaces.Domain;
using BBCChallenge.Domain.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmCross.Platform;

namespace BBCChallenge.DataServices.Online.Tests
{
    [TestClass]
    public class NewsOnlineDataServiceTests 
    {
        [TestInitialize]
        public void Init()
        {
            InitializeIoc.Init();
            IoCOnlineDataService.Register();
            IoCDomain.Register();
        }

        [TestMethod]
        public async Task NewsOnlineDataServiceTests_GetLatestNews()
        {
            var dataService = Mvx.Resolve<INewsOnlineDataService > ();
            var res = await dataService.GetLatestNews(NewsType.UK);
            Assert.IsNotNull(res.Data);
        }
    }
}
