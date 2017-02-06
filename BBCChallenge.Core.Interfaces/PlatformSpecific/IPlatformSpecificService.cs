namespace BBCChallenge.Core.Interfaces.PlatformSpecific
{
    public interface IPlatformSpecificService
    {
        bool HasInternetConnection();
        void ShowAlert(string title, string message);
    }
}