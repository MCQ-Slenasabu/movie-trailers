using movie_trailers.DAL.Services;
using movie_trailers.Interfaces;

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
                    return new OpenDBService();
                case MovieDBTypes.Rottendb:
                    return new RottenTrailerService();
                default:
                    return new OpenDBService();
            }
        }
    }
}