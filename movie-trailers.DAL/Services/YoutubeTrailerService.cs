using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using movie_trailers.Interfaces;
using System.Web;

namespace movie_trailers.DAL.Services
{
    public class YoutubeTrailerService : IVideo
    {
        YouTubeService youtube;
        SearchResource.ListRequest listRequest;
        SearchResult result;
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
            SearchListResponse resp = listRequest.Execute();
            if (resp.Items.Count > 0)
            {
                result = resp.Items[0];
                return ReturnGenericYoutubeUrl(IsEmbedded) + result.Id.VideoId.ToString();
            }
            return "";
        }
        private void AddListRequestProperties(string search)
        {
            listRequest = youtube.Search.List("snippet");
            listRequest.Q = search + "trailer";
            listRequest.MaxResults = 1;
            listRequest.Type = "video";
        }
        private string ReturnGenericYoutubeUrl(bool IsEmbedded)
        {
            return IsEmbedded ? "https://www.youtube.com/embed/" : HttpUtility.UrlEncode("https://www.youtube.com/watch?v=");
        }

    


    }
}
