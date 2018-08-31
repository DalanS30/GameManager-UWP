namespace GameManager_UWP
{
    public class Choice
    {
        public int Number { get; set; }
        public string Text { get; set; }
        public string ShortenedText
        {
            get
            {
                if (Text.Length <= 30) return Text;
                string substring = Text.Substring(0, 30);
                return substring.Substring(0, substring.LastIndexOf(" ")) + ". . .";
            }
        }
    }
}
