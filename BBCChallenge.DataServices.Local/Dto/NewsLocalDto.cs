using System;

namespace BBCChallenge.DataServices.Local.Dto
{
    public class NewsLocalDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }
}