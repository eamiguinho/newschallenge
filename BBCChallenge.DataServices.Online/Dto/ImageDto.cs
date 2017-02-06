using System.Xml.Serialization;

namespace BBCChallenge.DataServices.Online.Dto
{
    [XmlRoot(ElementName = "image")]
    public class ImageDto
    {
        [XmlElement(ElementName = "url")]
        public string Url { get; set; }
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
    }
}