using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace FishingApp.Models
{
    public class Catch
    {
        [Key]
        public int CatchID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }

        [ForeignKey("FishingMethod")]
        public int FishingMethodID { get; set; }
        public FishingMethod FishingMethod { get; set; }

        [ForeignKey("FishType")]
        public int FishTypeID { get; set; }
        public FishType FishType { get; set; }

        public int Difficulty { get; set; }
        public DateTime CatchDate { get; set; }

        [NotMapped]
        public GeoPoint Location { get; set; }

        public Point LocationPoint
        {
            get => Location?.ToPoint();
            set => Location = GeoPoint.FromPoint(value);
        }
    }
}
