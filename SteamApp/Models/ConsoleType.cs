using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SteamApp.Models
{
    public class ConsoleType
    {
        public byte ConsoleTypeID { get; set; }
        public string ConsoleName { get; set; }
        public short SignUpFee { get; set; }
        [Range(1,12)]
        public byte DurationInMonths { get; set; }

    }
}