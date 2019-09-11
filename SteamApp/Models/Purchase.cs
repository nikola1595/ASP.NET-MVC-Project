using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SteamApp.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DateOfPurchase { get; set; }
        
        public Client Client { get; set; }
        [Required]
        public int ClientID { get; set; }

        public Game Game { get; set; }
        [Required]
        public int GameID { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        [Required]
        public int PaymentMethodID { get; set; }
    }
}