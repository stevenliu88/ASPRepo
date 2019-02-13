using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public GenreDto Genre { get; set; }
        public DateTime? AddedToDB { get; set; }
        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }
        [Display(Name = "Number Available")]
        public int NumberAvailable { get; set; }
    }
}