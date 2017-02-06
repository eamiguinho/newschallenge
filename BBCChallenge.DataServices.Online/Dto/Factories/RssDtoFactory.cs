using System.Collections.Generic;
using System.Linq;
using BBCChallenge.Core.Interfaces.Domain;

namespace BBCChallenge.DataServices.Online.Dto.Factories
{
    public class RssDtoFactory
    {
        public static List<INews> GetListNews(RssDto result, NewsType type)
        {
            var list = new List<INews>();
            list.AddRange(result.Channel.Item.Select(x=>NewsDtoFactory.Create(x, type)).ToList());
            return list;
        }
    }
}