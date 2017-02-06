using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBCChallenge.Core.Interfaces.Services;
using BBCChallenge.UI.ViewModels.DataModels;
using MvvmCross.Core.ViewModels;

namespace BBCChallenge.UI.ViewModels.ViewModels
{
    public class NewsDetailViewModel : MvxViewModel
    {
        private readonly INewsService _newsService;
        private string _url;
        private string _title;

        public NewsDetailViewModel(INewsService newsService)
        {
            _newsService = newsService;
            var current = _newsService.GetCurrent();
            SelectedNews = new NewsDataModel(current);
            Title = current.Title;
            Url = current.Url;
        }

        public NewsDataModel SelectedNews { get; set; }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string Url
        {
            get { return _url; }
            set { SetProperty(ref _url, value); }
        }
    }
}
