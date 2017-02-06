using BBCChallenge.Core.Interfaces;
using BBCChallenge.Core.Interfaces.Domain;
using MvvmCross.Platform;

namespace BBCChallenge.DataServices.Local.Dto
{
    public class NewsLocalDtoFactory
    {
        public static NewsLocalDto CreateDto(INews news)
        {
            var dto = new NewsLocalDto();
            dto.Date = news.Date;
            dto.Description = news.Description;
            dto.Image = news.Image;
            dto.Title = news.Title;
            dto.Type = (int)news.Type;
            dto.Url = news.Url;
            return dto;
        }

        public static INews Create(NewsLocalDto dto)
        {
            var news = Mvx.Resolve<INews>();
            news.Date = dto.Date;
            news.Description = dto.Description;
            news.Image = dto.Image;
            news.Title = dto.Title;
            news.Type = (NewsType)dto.Type;
            news.Url = dto.Url;
            return news;
        }
    }
}