using System;
using System.Data;
using Dapper;

namespace MusicDatabaseFinal.Models
{
	public class MusicRepository : IMusicRepository
	{
        private readonly IDbConnection _conn;

		public MusicRepository(IDbConnection conn)
		{
            _conn = conn;
		}

        public IEnumerable<Music> GetAllMusic()
        {
            return _conn.Query<Music>("SELECT * FROM MUSIC;");
        }

        public Music GetMusic(int id)
        {
            return _conn.QuerySingle<Music>("SELECT * FROM MUSIC WHERE ID = @id", new { id = id });
        }

        public void UpdateMusic(Music music)
        {
            _conn.Execute("UPDATE MUSIC SET ArtistName = @artistName, AlbumName = @albumName, YearReleased = @yearReleased, Genre = @genre, MyRating = @myRating WHERE ID = @id",
                    new { artistName = music.ArtistName, albumName = music.AlbumName, yearReleased = music.YearReleased, genre = music.Genre, myRating = music.MyRating, id = music.ID });
        }
    }
}

