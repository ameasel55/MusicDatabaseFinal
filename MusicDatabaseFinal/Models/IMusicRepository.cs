using System;
namespace MusicDatabaseFinal.Models
{
	public interface IMusicRepository
	{
		public IEnumerable<Music> GetAllMusic();
		public Music GetMusic(int id);
		public void UpdateMusic(Music music);
	}
}

