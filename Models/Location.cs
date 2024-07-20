using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries; 

namespace FishingApp.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        [Required]
        [StringLength(50)]
        public string LocationName { get; set; }
        [StringLength(10)]
        public string WaterType { get; set; }
        public Polygon Area { get; set; } 
    }
}
