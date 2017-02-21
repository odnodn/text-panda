namespace TextPanda.Models
{
    public class Snippet
    {
        //public string Name { get; set; }
        public string Shortcut { get; set; }
        public string ReplaceWith { get; set; }
        public bool IsEnabled { get; set; } = true;
        public ReplaceMode ReplaceMode { get; set; } = ReplaceMode.Auto;
    }
}

