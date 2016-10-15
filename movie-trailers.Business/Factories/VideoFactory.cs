using movie_trailers.Custom_Apis;
using movie_trailers.Interfaces;

namespace movie_trailers
{
    class VideoFactory
    {
        public enum VideoTypes
        {
            Youtube,
            Vimeo
        }

        public static IVideo Get(VideoTypes type)
        {
            switch (type)
            {
                case VideoTypes.Youtube:
                    return new YouTubeApi();
                case VideoTypes.Vimeo:
                    return new VimeoApi();
                default:
                    return new YouTubeApi();
            }
        }

    }
}