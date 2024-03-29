﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace BookListRazer.Model
{
    public class Book
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Book Name")]
        public string Name { get; set; }
        
        public string ISBN { get; set; }

        public string Author { get; set; }
        
    }
}
