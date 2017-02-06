using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBCChallenge.Core.Interfaces;
using BBCChallenge.Core.Interfaces.DataServices;
using MvvmCross.Platform;

namespace BBCChallenge.DataServices.Online
{
    public class IoCOnlineDataService
    {
        public static void Register()
        {
            Mvx.ConstructAndRegisterSingleton<INewsOnlineDataService, NewsOnlineDataService>();
        }
    }
}
