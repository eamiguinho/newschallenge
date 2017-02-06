using BBCChallenge.Core.Interfaces.Domain;

namespace BBCChallenge.UI.ViewModels.DataModels
{
    public class NewsDataModel
    {
        private INews _model;

        public NewsDataModel(INews model)
        {
            _model = model;
        }
        
        public string Image => _model.Image;

        public string Title => _model.Title;
        public string Description => _model.Description;

        public string DateFormatted => _model.Date.ToString("f");
        public string Url => _model.Url;
        public INews Model => _model;

        public string Type => _model.Type == NewsType.UK ? "UK News" : "Tech";
    }
}