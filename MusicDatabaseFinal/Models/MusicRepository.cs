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

        public Music AssignMusic()
        {
            var musicList = GetMusic();
            var music = new Music();
            music.Musics = musicList;
            return music;
        }

        public IEnumerable<Music> GetAllMusic()
        {
            return _conn.Query<Music>("SELECT * FROM MUSIC;");
        }

        public Music GetMusic(int id)
        {
            return _conn.QuerySingle<Music>("SELECT * FROM MUSIC WHERE ID = @id", new { id = id });
        }

        public IEnumerable<Music> GetMusic()
        {
            return _conn.Query<Music>("SELECT * FROM music;");
        }

        public void InsertMusic(Music musicToInsert)
        {
            _conn.Execute("INSERT INTO music (ArtistName, AlbumName, YearReleased, Genre, MyRating) VALUES (@artistName, @albumName, @yearReleased, @genre, @myRating);",
                new {artistName = musicToInsert.ArtistName, albumName = musicToInsert.AlbumName, yearReleased = musicToInsert.YearReleased, genre = musicToInsert.Genre, myRating = musicToInsert.MyRating });
        }

        public void UpdateMusic(Music music)
        {
            _conn.Execute("UPDATE MUSIC SET ArtistName = @artistName, AlbumName = @albumName, YearReleased = @yearReleased, Genre = @genre, MyRating = @myRating WHERE ID = @id",
                    new { artistName = music.ArtistName, albumName = music.AlbumName, yearReleased = music.YearReleased, genre = music.Genre, myRating = music.MyRating, id = music.ID });
        }

        public void DeleteMusic(Music music)
        {
            _conn.Execute("DELETE FROM MUSIC WHERE ID = @id;", new { id = music.ID });
        }
    }
}

