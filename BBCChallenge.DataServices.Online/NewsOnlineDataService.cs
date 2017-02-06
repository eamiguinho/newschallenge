using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BBCChallenge.Core.Interfaces;
using BBCChallenge.Core.Interfaces.DataServices;
using BBCChallenge.Core.Interfaces.Domain;
using BBCChallenge.DataServices.Online.Dto;
using BBCChallenge.DataServices.Online.Dto.Factories;

namespace BBCChallenge.DataServices.Online
{
    public class NewsOnlineDataService : INewsOnlineDataService
    {
        public async Task<DataResult<List<INews>>> GetLatestNews(NewsType type)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var res = await httpClient.GetAsync(type == NewsType.UK ? "http://feeds.bbci.co.uk/news/uk/rss.xml" : "http://feeds.bbci.co.uk/news/technology/rss.xml");
                    var str = await res.Content.ReadAsStringAsync();
                    var serializer = new XmlSerializer(typeof(RssDto));
                    RssDto result;

                    using (TextReader reader = new StringReader(str))
                    {
                        result = (RssDto)serializer.Deserialize(reader);
                    }

                    if (result != null)
                    {
                        return new DataResult<List<INews>>(RssDtoFactory.GetListNews(result,type));
                    }
                    return new DataResult<List<INews>>(Result.Error);
                }
            }
            catch (Exception e)
            {
               return new DataResult<List<INews>>(e);
            }
        }
    }
}
