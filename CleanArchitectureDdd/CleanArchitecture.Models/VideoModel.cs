namespace CleanArchitecture.Models
{
    public class VideoModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StreamerId { get; set; }
        public virtual StreamerModel? Streamer { get; set; } //Virtual to be overwrited in the future by a derived class
    }
}
