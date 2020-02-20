using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models {
    public class Wedding {
        [Key]
        public int WeddingId { get; set; }
        [Required]
        [Display(Name = "Wedder One")]
        public string Wedder1 { get; set; }
        [Required]
        [Display(Name = "Wedder Two")]
        public string Wedder2 { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Wedding Address")]
        public string Address { get; set; }
        public int CreatorId { get; set; }
        public List<RSVP> RSVPs { get; set; }
    }
}