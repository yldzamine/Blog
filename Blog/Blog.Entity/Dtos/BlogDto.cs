namespace Blog.Entity.Dtos
{
    [Serializable]
    public class BlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Category { get; set; }
    }
}
