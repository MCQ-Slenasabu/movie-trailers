using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System.Web;
using movie_trailers.DAL.Interfaces;

namespace movie_trailers.DAL.Services
{
    public class YoutubeTrailerService : IVideo
    {
        readonly YouTubeService youtube;
        SearchResource.ListRequest _listRequest;
        SearchResult _result;
        public YoutubeTrailerService()
        {
            youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCo7GYi2K6-nHtPgipqFPNIpbRxJ8d1xkM", 
                ApplicationName = this.GetType().ToString()
            });
        }
        public string GetVideoUrl(string search, bool IsEmbedded)
        {
            AddListRequestProperties(search);
            SearchListResponse resp = _listRequest.Execute();
            if (resp.Items.Count > 0)
            {
                _result = resp.Items[0];
                return ReturnGenericYoutubeUrl(IsEmbedded) + _result.Id.VideoId.ToString();
            }
            return "";
        }
        private void AddListRequestProperties(string search)
        {
            _listRequest = youtube.Search.List("snippet");
            _listRequest.Q = search + "trailer";
            _listRequest.MaxResults = 1;
            _listRequest.Type = "video";
        }
        private string ReturnGenericYoutubeUrl(bool IsEmbedded)
        {
            return IsEmbedded ? "https://www.youtube.com/embed/" : HttpUtility.UrlEncode("https://www.youtube.com/watch?v=");
        }

    


    }
}
