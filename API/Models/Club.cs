namespace API.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public City City { get; set; }
    }
}