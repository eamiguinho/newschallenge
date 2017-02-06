using System.Collections.Generic;
using System.Xml.Serialization;

namespace BBCChallenge.DataServices.Online.Dto
{
    [XmlRoot(ElementName = "channel")]
    public class ChannelDto
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "link")]
        public string Link { get; set; }
        [XmlElement(ElementName = "image")]
        public ImageDto Image { get; set; }
        [XmlElement(ElementName = "generator")]
        public string Generator { get; set; }
        [XmlElement(ElementName = "lastBuildDate")]
        public string LastBuildDate { get; set; }
        [XmlElement(ElementName = "copyright")]
        public string Copyright { get; set; }
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
        [XmlElement(ElementName = "ttl")]
        public string Ttl { get; set; }
        [XmlElement(ElementName = "item")]
        public List<NewsDto> Item { get; set; }
    }
}