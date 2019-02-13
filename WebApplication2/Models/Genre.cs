using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication2.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        
        [Display(Name = "Genre")]
        public string Name { get; set; }
        
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        
        [Display(Name = "Number in Stock")]
        public byte Stock { get; set; }
    }
}