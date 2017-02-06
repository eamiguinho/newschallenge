using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBCChallenge.Core.Interfaces;
using BBCChallenge.Core.Interfaces.Domain;
using MvvmCross.Platform;

namespace BBCChallenge.Domain.Implementation
{
    public class IoCDomain
    {
        public static void Register()
        {
            Mvx.RegisterType<INews,News>();
        }
    }
}
