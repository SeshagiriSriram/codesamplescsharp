using System.Configuration;
namespace ACrazyCatsExample
{
    public class CatConfiguration: ConfigurationElement
    {
        private const string NameKey = "name";
        private const string ColorKey = "color";
        private const string AgeKey = "age";
        //private const string _NoAgeSpecified = "0";

        [ConfigurationProperty(NameKey, IsRequired = true)]
        public string Name => (string)this[NameKey];

        [ConfigurationProperty(ColorKey, IsRequired = false, DefaultValue = "<undefined>")]
        public string Color => (string)this[ColorKey];

        [ConfigurationProperty(AgeKey, IsRequired = false, DefaultValue = 0)]
        public int Age => (int)this[AgeKey];
    }
}
