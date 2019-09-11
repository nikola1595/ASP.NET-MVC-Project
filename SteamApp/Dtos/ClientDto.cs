using SteamApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SteamApp.Dtos
{
    public class ClientDto
    {
        public int ClientID { get; set; }
        [Required]
        [StringLength(255)]

        public string Name { get; set; }
        public bool IsSubscribedOnSteam { get; set; }

        public ConsoleTypeDto ConsoleType { get; set; }
        
        public byte ConsoleTypeID { get; set; }
    }
}