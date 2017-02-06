using System.Xml.Serialization;

namespace BBCChallenge.DataServices.Online.Dto
{
    [XmlRoot(ElementName = "rss")]
    public class RssDto
    {
        [XmlElement(ElementName = "channel")]
        public ChannelDto Channel { get; set; }
        [XmlAttribute(AttributeName = "dc", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Dc { get; set; }
        [XmlAttribute(AttributeName = "content", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Content { get; set; }
        [XmlAttribute(AttributeName = "atom", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Atom { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "media", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Media { get; set; }
    }
}