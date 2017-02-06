using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using BBCChallenge.Core.Interfaces;
using BBCChallenge.Core.Interfaces.Domain;
using BBCChallenge.Core.Interfaces.PlatformSpecific;
using BBCChallenge.Core.Interfaces.Services;
using BBCChallenge.UI.Android.Views;
using BBCChallenge.UI.ViewModels.DataModels;
using MvvmCross.Core.ViewModels;

namespace BBCChallenge.UI.ViewModels.ViewModels
{
    public class NewsListViewModel : MvxViewModel
    {
        private readonly INewsService _newsService;
        private ObservableCollection<NewsDataModel> _news;
        private IPlatformSpecificService _platformSpecificService;
        private List<INews> _allNews;

        public NewsListViewModel(INewsService newsService, IPlatformSpecificService platformSpecificService)
        {
            _newsService = newsService;
            _platformSpecificService = platformSpecificService;
        }

        public ObservableCollection<NewsDataModel> News { get
        {
            return _news ?? (_news = new ObservableCollection<NewsDataModel>());
        } }

        public bool HasInternet => !_platformSpecificService.HasInternetConnection();

        public virtual ICommand ItemSelected
        {
            get
            {
                return new MvxCommand<NewsDataModel>(item =>
                {
                    _newsService.SetCurrent(item.Model);
                    ShowViewModel<NewsDetailViewModel>();
                });
            }
        }

        public async Task LoadData()
        {
            RaisePropertyChanged(()=> HasInternet);
            var result = await _newsService.GetLatestNews();
            if (result.IsOk)
            {
                _allNews = result.Data;
                foreach (var news in result.Data)
                {
                    News.Add(new NewsDataModel(news));
                }
            }
            else
            {
                switch (result.Result)
                {
                    case Result.Ok:
                        break;
                    case Result.Error:
                        _platformSpecificService.ShowAlert("Unexpected error occurred", "Please try again later");
                        break;
                    case Result.Unauthorized:
                        break;
                    case Result.NoInternetConnection:
                        _platformSpecificService.ShowAlert("No internet connection", "Please check your internet connection and try again");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
              
            }
        }

        public void Filter(FilterOptions all)
        {
            if (_allNews == null) return;
            News.Clear();
            List<INews> filterList;
            switch (all)
            {
                case FilterOptions.All:
                    filterList = _allNews;
                    break;
                case FilterOptions.Uk:
                    filterList = _allNews.Where(x => x.Type == NewsType.UK).ToList();
                    break;
                case FilterOptions.Tech:
                    filterList = _allNews.Where(x => x.Type == NewsType.Tech).ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(all), all, null);
            }
            foreach (var allNew in filterList)
            {
                News.Add(new NewsDataModel(allNew));
            }
        }
    }
}
