using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SteamApp.Dtos
{
    public class ConsoleTypeDto
    {
        public byte ConsoleTypeID { get; set; }
        public string ConsoleName { get; set; }
        public short SignUpFee { get; set; }
        [Range(1, 12)]
        public byte DurationInMonths { get; set; }
    }
}