using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Display(Name= "Genre")]
        [Required]
        public byte GenreId { get; set; }
        [Display(Name="Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime? AddedToDB { get; set; }
        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }
    }
}