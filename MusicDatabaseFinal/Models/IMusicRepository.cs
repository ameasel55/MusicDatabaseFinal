using System;
namespace MusicDatabaseFinal.Models
{
	public interface IMusicRepository
	{
		public IEnumerable<Music> GetAllMusic();
		public Music GetMusic(int id);
		public void UpdateMusic(Music music);
        public void InsertMusic(Music musicToInsert);
        public IEnumerable<Music> GetMusic();
        public Music AssignMusic();
		public void DeleteMusic(Music music);
    }
}

