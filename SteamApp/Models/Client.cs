using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SteamApp.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        [Required]
        [StringLength(255)]

        public string Name { get; set; }
        public bool IsSubscribedOnSteam { get; set; }
        
        public ConsoleType ConsoleType { get; set; }
        [Display(Name = "Console type")]
        public byte ConsoleTypeID { get; set; }


        
    }
}