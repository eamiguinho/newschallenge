using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBCChallenge.Core.Interfaces.Domain;

namespace BBCChallenge.Domain.Implementation
{
    public class News : INews
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public NewsType Type { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }
}
