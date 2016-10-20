using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using movie_trailers.Interfaces;
using System.Web;

namespace movie_trailers.Custom_Apis
{
    public class YouTubeApi : IVideo 
    {
        YouTubeService youtube;
        public YouTubeApi()
        {
            youtube = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCo7GYi2K6-nHtPgipqFPNIpbRxJ8d1xkM", //ConfigurationManager.AppSettings["YoutubeApiKey"],
                ApplicationName = this.GetType().ToString()
            });
        }

        public string GetVideoUrl(string search, bool IsEmbedded)
        {
            SearchResult result;
            SearchResource.ListRequest listRequest = youtube.Search.List("snippet");
            listRequest.Q = search + "trailer";
            listRequest.MaxResults = 1;
            listRequest.Type = "video";
            SearchListResponse resp = listRequest.Execute();
            if(resp.Items.Count > 0)
            {
                result = resp.Items[0];
                return ReturnGenericYoutubeUrl(IsEmbedded) + result.Id.VideoId.ToString();
            }
            return "";
        }

        private string ReturnGenericYoutubeUrl(bool IsEmbedded)
        {
            return IsEmbedded ? "https://www.youtube.com/embed/" : HttpUtility.UrlEncode("https://www.youtube.com/watch?v=");
        }

    }
}