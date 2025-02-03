namespace CleanArchitecture.Models
{
    public class StreamerModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Url { get; set; }

        //Relationships:

        public ICollection<VideoModel> VideoModels { get; set; }
    }
}
