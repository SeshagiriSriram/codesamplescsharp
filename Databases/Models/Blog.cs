using System.ComponentModel.DataAnnotations.Schema;

namespace csharp.training.congruent.classes
{
    [Table("Blogs", Schema = "training")]

    public class Blog
    {
        public int BlogId { get; set; }
        private string _name; 
        private string _url;
        public string Name 
        { 
            get { return _name; } 
            set { _name = value; }
        }   
        public string Url 
        { 
            get { return _url; } 
            set { _url = value; }
        }
        public Blog()
        {
            _name = "Default Blog Name";
            _url   = "http://defaultblogurl.com";
        }
        public Blog(string name, string url)
        {
            _name = name;
            _url = url;
        }
         public Blog(int id, string name, string url)
        {
            BlogId = id;
            _name = name;
            _url  = url;
        }
        public override string ToString()
        {
            return $"BlogId: {BlogId}, Name: {_name}, Url: {_url}";
        }
        private readonly List<Post> posts = [];
        public List<Post> Posts 
        { 
            get { return posts; }
        }

    }
}
