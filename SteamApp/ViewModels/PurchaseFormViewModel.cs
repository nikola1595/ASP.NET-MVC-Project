using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SteamApp.Models;

namespace SteamApp.ViewModels
{
    public class PurchaseFormViewModel
    {
        
        public IEnumerable<Client> Clients { get; set; }
        public IEnumerable<Game> Games { get; set; }
        public IEnumerable<PaymentMethod> PaymentMethods { get; set; }

        public int PurchaseID { get; set; }
        
        
        public int ClientID { get; set; }
        public int GameID { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int PaymentMethodID { get; set; }

        public PurchaseFormViewModel()
        {
            PurchaseID = 0;
            
            DateOfPurchase = DateTime.Now;
            
        }


        public PurchaseFormViewModel(Purchase purchase)
        {
            PurchaseID = purchase.PurchaseID;
            ClientID = purchase.ClientID;
            GameID = purchase.GameID;
            DateOfPurchase = purchase.DateOfPurchase;
            PaymentMethodID = purchase.PaymentMethodID;
            
        }
    }

}