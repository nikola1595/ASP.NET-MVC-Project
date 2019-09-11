using SteamApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SteamApp.ViewModels
{
    public class ClientFormViewModel
    {
        public IEnumerable<ConsoleType> ConsoleTypes { get; set; }

        public Client Client { get; set; }
    }
}