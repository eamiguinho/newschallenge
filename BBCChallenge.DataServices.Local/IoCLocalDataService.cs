using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBCChallenge.Core.Interfaces;
using BBCChallenge.Core.Interfaces.DataServices;
using BBCChallenge.Core.Interfaces.Services;
using MvvmCross.Platform;

namespace BBCChallenge.DataServices.Local
{
    public class IoCLocalDataService
    {
        public static void Register()
        {
            Mvx.ConstructAndRegisterSingleton<INewsLocalDataService, NewsLocalDataService>();
        }
    }
}
