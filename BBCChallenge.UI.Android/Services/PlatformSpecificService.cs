using Android.Support.V7.App;
using BBCChallenge.Core.Interfaces.PlatformSpecific;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using Plugin.Connectivity;

namespace BBCChallenge.UI.Android.Services
{
    public class PlatformSpecificService : IPlatformSpecificService
    {
        public bool HasInternetConnection()
        {
            return CrossConnectivity.Current.IsConnected;
        }


        public void ShowAlert(string title, string message)
        {
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            AlertDialog.Builder alert = new AlertDialog.Builder(topActivity.Activity);

            alert.SetTitle(title);
            alert.SetMessage(message);

            alert.SetNeutralButton("Ok", (senderAlert, args) => {
            });

            topActivity.Activity.RunOnUiThread(() => {
                alert.Show();
            });
        }
    }
}