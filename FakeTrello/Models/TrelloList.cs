﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FakeTrello.Models
{
    public class TrelloList
    {
        [Key]
        public int ListId { get; set; }

        public string Name { get; set; }
    }
}