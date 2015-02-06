using System;
using System.Collections.Generic;
using System.Text;

namespace DeezerWin2dExperiments
{
    class Album
    {
        public Album()
        {
            Tracks = new List<Song>();
        }

        public string Title { get; set; }
        
        public string ArtistName { get; set; }
        
        public Uri AlbumCoverUri { get; set; }
        
        public Uri ArtistImageUri { get; set; }

        public List<Song> Tracks { get; set; }
        public int Fans { get; set; }
    }
}
