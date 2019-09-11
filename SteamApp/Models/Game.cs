using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SteamApp.Models
{
    public class Game
    {
        public int GameID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name="Game Published")]
        public int GameYearPublished {get;set;}
        [Display(Name="Platform")]
        public string GameFor { get; set; }
        public Category Category { get; set; }
        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        [Display(Name="Game Price")]
        public int GamePrice { get; set; }

        
    }
}