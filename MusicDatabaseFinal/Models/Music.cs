using System;
namespace MusicDatabaseFinal.Models
{
	public class Music
	{
		public Music()
		{
		}
        public int ID { get; set; }

        public string ArtistName { get; set; }

        public string AlbumName { get; set; }

        public int YearReleased { get; set; }

        public string Genre { get; set; }

        public double MyRating { get; set; }
    }
}

