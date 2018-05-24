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

        [Required]
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
        public string DateOpened { get; set; }

        public byte NumberOfOpenings { get; set; }
    }
}