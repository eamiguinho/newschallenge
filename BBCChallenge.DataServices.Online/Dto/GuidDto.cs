using System.Xml.Serialization;

namespace BBCChallenge.DataServices.Online.Dto
{
    [XmlRoot(ElementName = "guid")]
    public class GuidDto
    {
        [XmlAttribute(AttributeName = "isPermaLink")]
        public string IsPermaLink { get; set; }
        [XmlText]
        public string Text { get; set; }
    }
}