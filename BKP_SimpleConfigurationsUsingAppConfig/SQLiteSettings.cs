using System.Configuration;
namespace csharp.training.congruent.apps
{
    public class SQLiteSettings : ConfigurationSection
    {
        [ConfigurationProperty("folder", IsRequired = true)]
        public string Folder
        {
            get => (string)this["folder"];
            set => this["folder"] = value;
        }

        [ConfigurationProperty("db", IsRequired = true)]
        public string Db
        {
            get => (string)this["db"];
            set => this["db"] = value;
        }
    }

}
