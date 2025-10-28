using System.Configuration;
namespace csharp.training.congruent.apps
{
    public class CoreAppSettings : ConfigurationSection
    {
        public CoreAppSettings()
        {
            Console.WriteLine(this.ToString());
        }
        [ConfigurationProperty("dbType", IsRequired = true)]
        public string DbType
        {
            get => (string)this["dbType"];
            set => this["dbType"] = value;
        }
    }

}
