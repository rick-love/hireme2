using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using HireMe2.Models;

namespace HireMe2.ViewModels
{
    public class RequisitionFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string RequisitionTitle { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Display(Name = "Date Opened")]
        [Required]
        public DateTime DateOpened { get; set; }

        [Display(Name = "Number Of Openings")]
        [Range(1, 10)]
        [Required]
        public byte? NumberOfOpenings { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Requisition" : "New Requisition";
            }
        }

        public RequisitionFormViewModel()
        {
            Id = 0;
        }

        public RequisitionFormViewModel(Requisition requisition)
        {
            Id = requisition.Id;
            RequisitionTitle = requisition.Title;
            DateOpened = requisition.DateOpened;
            NumberOfOpenings = requisition.NumberOfOpenings;
            GenreId = requisition.GenreId;
        }

    }
}