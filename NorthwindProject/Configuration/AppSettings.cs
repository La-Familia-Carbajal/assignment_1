namespace NorthwindProject.Configuration
{
    public class AppSettings
    {
        public class ConnectionStringSettings
        {
            public string Default
            {
                get; set;
            }
        }
        
        public ConnectionStringSettings ConnectionStrings
        {
            get; set;
        }
    }
}
