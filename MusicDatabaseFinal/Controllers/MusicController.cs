using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicDatabaseFinal.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicDatabaseFinal.Controllers
{
    public class MusicController : Controller
    {
        private readonly IMusicRepository repo;

        public MusicController(IMusicRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var music = repo.GetAllMusic();
            return View(music);
        }

        public IActionResult ViewMusic(int id)
        {
            var product = repo.GetMusic(id);
            return View(product);
        }
    }
}

