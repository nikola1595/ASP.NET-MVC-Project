using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SteamApp.Models
{
    public class Category
    {

        public int CategoryID { get; set; }
        [Required]
        [StringLength(255)]
        public string CategoryName { get; set; }
        public string CategoryDetails { get; set; }
    }
}