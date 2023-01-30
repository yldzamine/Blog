namespace Blog.Entity.Dtos
{
    public class BlogInsertDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Category { get; set; }
    }
}
