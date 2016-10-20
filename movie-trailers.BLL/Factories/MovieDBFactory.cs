using movie_trailers.DAL.Interfaces;
using movie_trailers.DAL.Services;

namespace movie_trailers
{
    class MovieDBFactory
    {
        public enum MovieDBTypes
        {
            Opendb,
            Rottendb
        }

        public static IMovie Get(MovieDBTypes type)
        {
            switch (type)
            {
                case MovieDBTypes.Opendb:
                    return new OpenDbService();
                case MovieDBTypes.Rottendb:
                    return new RottenTrailerService();
                default:
                    return new OpenDbService();
            }
        }
    }
}