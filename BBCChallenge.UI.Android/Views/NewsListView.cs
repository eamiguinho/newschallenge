using System;
using Android.App;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using BBCChallenge.UI.ViewModels.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace BBCChallenge.UI.Android.Views
{
    [Activity(Label = "News Challenge", Theme = "@style/MyTheme", MainLauncher = true)]
    public class NewsListView : MvxAppCompatActivity
    {
        private NewsListViewModel _newsListViewModel;
        private SwipeRefreshLayout _swiperefresh;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetSupportActionBar(toolbar);

            _swiperefresh = FindViewById<SwipeRefreshLayout>(Resource.Id.swiperefresh);
            _swiperefresh.Refresh += Swiperefresh_Refresh;

            SupportActionBar.Title = "News Challenge";
            _newsListViewModel = ViewModel as NewsListViewModel;
            _newsListViewModel?.LoadData();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.filtermenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.showall:
                    _newsListViewModel.Filter(FilterOptions.All);
                    return true;
                case Resource.Id.showuk:
                    _newsListViewModel.Filter(FilterOptions.Uk);
                    return true;
                case Resource.Id.showtech:
                    _newsListViewModel.Filter(FilterOptions.Tech);
                    return true;
                default:
                   return base.OnOptionsItemSelected(item);
            }
        }

        private async void Swiperefresh_Refresh(object sender, EventArgs e)
        {
            _swiperefresh.Refreshing = true;
            await _newsListViewModel.LoadData();
            _swiperefresh.Refreshing = false;
        }

    }
}