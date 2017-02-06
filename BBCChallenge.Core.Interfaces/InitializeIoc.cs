using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace BBCChallenge.Core.Interfaces
{
    public class InitializeIoc
    {
        public static void Init()
        {
            var options = new MvxIocOptions();

            // initialize the IoC registry, then add it to itself
            var iocProvider = MvxSimpleIoCContainer.Initialize(options);
            Mvx.RegisterSingleton(iocProvider);
        }
    }
}
