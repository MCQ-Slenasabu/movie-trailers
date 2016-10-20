namespace movie_trailers.DAL.Interfaces
{
    public interface IVideo
    {
        string GetVideoUrl(string search, bool embbed);
    }
}
