using System.Collections.Generic;
using System.Text;

namespace GameManager_UWP
{
    public class Scenario
    {
        public string ID { get; set; }
        public string Text { get; set; }
        public List<Choice> Choices { get; set; }
        public string TextWithChoices
        {
            get
            {
                StringBuilder b = new StringBuilder();
                b.AppendLine(Text);
                b.AppendLine(string.Empty);
                foreach (Choice choice in Choices)
                {
                    b.AppendLine($"{choice.Number}) {choice.Text}");
                }
                return b.ToString();
            }
        }
        public string ResolvedText { get { return ChoicesAvailable ? TextWithChoices : Text; } }
        public bool ChoicesAvailable { get { return Choices != null && Choices.Count > 0; } }
    }
}
