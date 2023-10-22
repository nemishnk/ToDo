namespace ToDoAPI.Helper
{
    public static class AppSettingsHelper
    {
        public  static IConfiguration _configuration;

        static  AppSettingsHelper()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(System.AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }
        public  static dynamic GetValue(string key)
        {
           return  _configuration.GetValue<dynamic>(key);

        }
    }
}
