using movie_trailers.Interfaces;
using System;

namespace movie_trailers.Custom_Apis
{
    public class VimeoApi : IVideo
    {
        public string GetVideoUrl(string search, bool embbed)
        {
            throw new NotImplementedException();
        }
    }
}