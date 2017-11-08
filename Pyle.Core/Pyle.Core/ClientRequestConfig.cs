namespace Pyle.Core
{
    public class ClientRequestConfig
    {
        public string Filter { get; set; }

        public ClientRequestConfig(string filter = "default")
        {
            Filter = filter;
        }
    }
}
