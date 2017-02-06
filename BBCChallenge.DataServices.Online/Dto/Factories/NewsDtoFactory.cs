using System;
using BBCChallenge.Core.Interfaces;
using BBCChallenge.Core.Interfaces.Domain;
using MvvmCross.Platform;

namespace BBCChallenge.DataServices.Online.Dto.Factories
{
    public class NewsDtoFactory
    {
        public static INews Create(NewsDto newsDto, NewsType type)
        {
            var news = Mvx.Resolve<INews > ();
            news.Description = newsDto.Description; 
            news.Image = newsDto.Thumbnail.Url;
            news.Url = newsDto.Link;
            news.Title = newsDto.Title;
            news.Date = DateTime.Parse(newsDto.PubDate);
            news.Type = type;
            return news;
        }
    }
}