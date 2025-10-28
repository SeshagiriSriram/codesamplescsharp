using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace csharp.training.congruent.classes
{
    [Table("RSSBlogs", Schema = "training")]
    public class RSSBlog:Blog
    {
        private string _url;
        public new string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public string RSSUrl { get; set; }

        public RSSBlog():base()
        {
            _url = string.Empty;
            RSSUrl = "Default RSS URL";
        }
        public RSSBlog(string name, string url):base(name,url)      
        {
            _url = url;
            Url = url; 
            Name = name; 
            RSSUrl = "Default RSS URL";

        }
        public RSSBlog(int id, string name, string url):base(id,name,url)
        {
            BlogId = id; 
            _url = url;
            Url = url;
            Name = name;
            RSSUrl = "Default RSS URL";

        }

        public RSSBlog(int id, string name, string url,string rssurl) 
        {
            BlogId = id;
            Name = name;
            _url = url;
            Url = url;
            RSSUrl = rssurl;
        }
        public override string ToString()
        {
            return $"RSS BlogId: {BlogId}, Name: {Name}, Url: {Url}";
        }

    }
}
