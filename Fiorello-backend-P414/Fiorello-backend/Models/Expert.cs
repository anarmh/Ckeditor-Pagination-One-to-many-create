namespace Fiorello_backend.Models
{
    public class Expert:BaseEntity
    {
        public string FullName { get; set; }
        public string Image { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
