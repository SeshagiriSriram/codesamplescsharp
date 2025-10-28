using System.Configuration;
namespace csharp.training.congruent.apps
{
    public class SQLServerSettings : ConfigurationSection
    {
        [ConfigurationProperty("user", IsRequired = true)]
        public string User
        {
            get => (string)this["user"];
            set => this["user"] = value;
        }

        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get => (string)this["password"];
            set => this["password"] = value;
        }

        [ConfigurationProperty("db", IsRequired = true)]
        public string Db
        {
            get => (string)this["db"];
            set => this["db"] = value;
        }

        [ConfigurationProperty("server", IsRequired = true)]
        public string Server
        {
            get => (string)this["server"];
            set => this["server"] = value;
        }

        public string GetConnectionString()
        {
            //return $"Server={Server};Database={Db};Initial Catalog={Db};Trusted_Connection=true;User Id={User};Password={Password};";
            return $"Server={Server};Database={Db};Initial Catalog={Db};Trusted_Connection=true;";
        }
    }

}
