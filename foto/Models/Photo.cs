namespace foto.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Visibile { get; set; }
        public List<Category>? Categories { get; set; }

        public Photo() { }
    }
}
