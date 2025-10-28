using System.ComponentModel.DataAnnotations.Schema;

namespace csharp.training.congruent.classes
{
    [Table("Posts", Schema = "training")]
    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Blog Blog { get; set; } = new Blog();
        private readonly List<Comments> comments = [];
        public List<Comments> Comments 
        { 
            get { return comments; }
        }
    }
}
