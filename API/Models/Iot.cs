using System.Collections.Generic;

namespace API.Models
{
    public class Iot
    {
        public int Id { get; set; }
        public Club Club { get; set; }
        public virtual ICollection<IotConstituent> IotConstituents { get; set; }
    }
}