using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UglyChinook
{
    class Program
    {
        static void Main(string[] args)
        {
            ArtistData ad = new ArtistData();

            // insert
            Artist newArtist = new Artist();
            newArtist.Name = "트와이스";
            ad.Insert(newArtist);

            // update
            List<Artist> artists = ad.GetAllArtists2();
            Artist artist = artists[0];
            artist.Name = "레드벨벨";
            ad.Update(artist);

            // delete
            artists = ad.GetAllArtists2();
            Artist artistToDelete = artists[0];
            ad.Delete(artistToDelete);
            
        }

        
    }
}
