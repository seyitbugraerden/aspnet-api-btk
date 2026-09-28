using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIBlog.WebApi.Entities
{
    public class TradingVideo
    {
        public int TradingVideoId { get; set; }
        public string Title { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EmbedVideoUrl { get; set; }
    }
}