using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using BBCChallenge.UI.ViewModels.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using Plugin.Share;
using Plugin.Share.Abstractions;

namespace BBCChallenge.UI.Android.Views
{
    [Activity(Label = "News Challenge", Theme = "@style/MyTheme")]
    public class NewsDetailView : MvxAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.news_detail_layout);

            var toolbar = FindViewById<Toolbar>(Resource.Id.main_toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            var share = FindViewById<FloatingActionButton>(Resource.Id.shareButton);
            share.Click += Share_Click;
        }

        private async void Share_Click(object sender, System.EventArgs e)
        {
            var vm = ViewModel as NewsDetailViewModel;
            if (vm != null)
                await CrossShare.Current.Share(new ShareMessage
                {
                    Title = vm.SelectedNews.Title,
                    Text = vm.SelectedNews.Description,
                    Url = vm.SelectedNews.Url
                });
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            OnBackPressed();
            return base.OnOptionsItemSelected(item);
        }
    }
}