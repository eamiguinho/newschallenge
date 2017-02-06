using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBCChallenge.Core.Interfaces.DataServices;
using BBCChallenge.Core.Interfaces.Domain;
using BBCChallenge.DataServices.Local.Dto;
using Newtonsoft.Json;
using PCLStorage;

namespace BBCChallenge.DataServices.Local
{
    public class NewsLocalDataService : INewsLocalDataService
    {
        public async Task SaveLatestNews(List<INews> list)
        {
            try
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFile file = await rootFolder.CreateFileAsync("news.json", CreationCollisionOption.ReplaceExisting);
                await file.WriteAllTextAsync(JsonConvert.SerializeObject(list.Select(NewsLocalDtoFactory.CreateDto)));
            }
            catch (Exception e)
            {

            }
        }

        public async Task<List<INews>> GetSavedNews()
        {
            try
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFile file = await rootFolder.GetFileAsync("news.json");
                var json = await file.ReadAllTextAsync();
                var listNews = JsonConvert.DeserializeObject<List<NewsLocalDto>>(json);
                return listNews.Select(NewsLocalDtoFactory.Create).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
