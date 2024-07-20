using System.Collections.Generic;

namespace FishingApp.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }

        public ICollection<Catch> Catches { get; set; }
    }
}
