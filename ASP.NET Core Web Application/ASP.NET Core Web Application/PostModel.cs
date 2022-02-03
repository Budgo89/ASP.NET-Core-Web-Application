namespace ASP.NET_Core_Web_Application
{
    public class PostModel
    {
        public override string ToString() => $"{UserId}\n{Id}\n{Title}\n{Body}\n";

        public uint UserId { get; set; }
        public uint Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}