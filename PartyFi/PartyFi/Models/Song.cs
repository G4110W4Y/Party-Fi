﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyFi.Models
{
    public class Song
    {
        public int ID { get; set; }
        public int rank { get; set; }
        public string song { get; set; }
        public string atrist { get; set; }
        public string URI { get; set; }
        public bool hasPlayed { get; set; }


    }
}