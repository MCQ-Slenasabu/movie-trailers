using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace movie_trailers.Models
{
    public class Movie
    {
        [JsonProperty("Title")]
        public string Title { get; set; }
        [JsonProperty("Year")]
        public string Year { get; set; }
        [JsonProperty("Released")]
        public string Released { get; set; }
        [JsonProperty("Runtime")]
        public string Runtime { get; set; }
        [JsonProperty("Genre")]
        public string Genre { get; set; }
        [JsonProperty("Director")]
        public string Director { get; set; }
        [JsonProperty("Writer")]
        public string Writer { get; set; }
        [JsonProperty("Actors")]
        public string Actors { get; set; }
        [JsonProperty("Plot")]
        public string Plot { get; set; }
        [JsonProperty("Language")]
        public string Language { get; set; }
        [JsonProperty("Country")]
        public string Country { get; set; }
        [JsonProperty("Awards")]
        public string Awards { get; set; }
        [JsonProperty("Poster")]
        public string Poster { get; set; }
        [JsonProperty("Metascore")]
        public string Metascore { get; set; }

        [JsonProperty("YoutubeSrc")]
        public string Src { get; set; }

        [JsonProperty("YoutubeEmbeddedSrc")]
        public string EmbeddedSrc { get; set; }

    }
}

//{"Title":"Capturing Captain Phillips",
//"Year":"2014","Rated":"N/A",
//"Released":"21 Jan 2014",
//"Runtime":"58 min",
//"Genre":"Documentary",
//"Director":"N/A",
//"Writer":"N/A",
//"Actors":"Paul Greengrass, Richard Phillips, Andrea Phillips, Gregory Goodman",
//"Plot":"N/A",
//"Language":"English",
//"Country":"USA",
//"Awards":"N/A",
//"Poster":"N/A",
//"Metascore":"N/A",
//"imdbRating":"5.6",
//"imdbVotes":"5",
//"imdbID":"tt4355704",
//"Type":"movie",
//"Response":"True"}