using BBCChallenge.DataServices.Local;
using BBCChallenge.DataServices.Online;
using BBCChallenge.Domain.Implementation;
using BBCChallenge.Services.Implementation;
using BBCChallenge.UI.ViewModels.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace BBCChallenge.UI.ViewModels
{
    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterSingleton<IMvxAppStart>(new MvxAppStart<NewsListViewModel>());
        }
    }
}