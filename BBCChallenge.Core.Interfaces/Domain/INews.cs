using System;

namespace BBCChallenge.Core.Interfaces.Domain
{
    public interface INews
    {
        string Title { get; set; }
        string Description { get; set; }
        string Image { get; set; }
        NewsType Type { get; set; }
        string Url { get; set; }
        DateTime Date { get; set; }
    }
}