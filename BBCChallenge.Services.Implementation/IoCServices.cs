using BBCChallenge.Core.Interfaces;
using BBCChallenge.Core.Interfaces.Services;
using MvvmCross.Platform;

namespace BBCChallenge.Services.Implementation
{
    public class IoCService
    {
        public static void Register()
        {
            Mvx.ConstructAndRegisterSingleton<INewsService, NewsService>();
        }
    }
}
