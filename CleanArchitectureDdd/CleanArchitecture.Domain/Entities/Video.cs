namespace CleanArchitecture.Domain.Entities
{
    public class Video
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StreamerId { get; set; }
        public virtual Streamer? Streamer { get; set; } //Virtual to be overwrited in the future by a derived class
    }
}
