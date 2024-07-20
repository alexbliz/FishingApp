using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FishingApp.Models
{
    public class FishType
    {
        [Key]
        public int FishTypeID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<Catch> Catches { get; set; } 
    }
}
