namespace LibraryManagement
{
    public class DataConfig
    {
        public string ConnectionString { get; set; }
        public DataConfig() {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var ConString = configuration.GetSection("ConnectionStrings").GetValue<string>("MSSQLServerDBConnection");
            this.ConnectionString = ConString;
        }
    }
}
