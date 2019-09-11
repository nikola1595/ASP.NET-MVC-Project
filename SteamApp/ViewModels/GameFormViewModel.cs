using SteamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApp.ViewModels
{
    public class GameFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public Game Game { get; set; }

    }
}