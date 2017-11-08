using System.Collections.Generic;

namespace API.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Club> Clubs { get; set; }
    }
}