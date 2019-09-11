using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteamApp.Models;

namespace SteamApp.ViewModels
{
    public class RandomGameViewModel
    {
        public Game Game { get; set; }
        public List<Client> Clients { get; set; }
        

    }
}