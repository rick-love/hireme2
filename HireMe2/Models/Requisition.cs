using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HireMe2.Models
{
    public class Requisition
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateOpened { get; set; }

        [Display(Name = "Number of Openings")]
        [Range(1, 10)]
        public byte NumberOfOpenings { get; set; }
    }
}