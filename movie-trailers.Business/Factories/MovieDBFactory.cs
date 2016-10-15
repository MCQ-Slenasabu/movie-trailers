using movie_trailers.Custom_Apis;
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
                    return new OpendbApi();
                case MovieDBTypes.Rottendb:
                    return new RottenApi();
                default:
                    return new OpendbApi();
            }
        }
    }
}