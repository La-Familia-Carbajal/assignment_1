namespace NorthwindProject.Configuration
{
    public class AppSettings
    {
        public class ConnectionStringSettings
        {
            public string Default { get; set; } = string.Empty;
        }

        public ConnectionStringSettings ConnectionStrings { get; set; } = new ConnectionStringSettings();
    }
}
