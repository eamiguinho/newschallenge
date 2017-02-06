using System.Xml.Serialization;

namespace BBCChallenge.DataServices.Online.Dto
{
    [XmlRoot(ElementName = "thumbnail", Namespace = "http://search.yahoo.com/mrss/")]
    public class ThumbnailDto
    {
        [XmlAttribute(AttributeName = "width")]
        public string Width { get; set; }
        [XmlAttribute(AttributeName = "height")]
        public string Height { get; set; }
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }
}