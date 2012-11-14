using System;
using System.Globalization;
using System.Windows.Documents;
using System.Windows.Media;

namespace Touch
{
    public class Symbol
    {
        private static readonly Brush WhiteBrush = new SolidColorBrush(Colors.White);
        private static readonly Brush RedBrush = new SolidColorBrush(Colors.Red);
        private static readonly Brush LightGrayBrush = new SolidColorBrush(Colors.LightGray);
        private static readonly Brush BlackBrush = new SolidColorBrush(Colors.Black);

        public Symbol(char c)
        {
            IsWhitespace = c == '\n' || c == ' ';
            if (c == '\n')
            {
                UnusedText = Environment.NewLine;
                // http://en.wikipedia.org/wiki/Pilcrow
                UsedText = "¶" + Environment.NewLine;
                Character = ' ';
            }
            else if (c == ' ')
            {
                UnusedText = " ";
                UsedText = "˽";
                Character = ' ';
            }
            else
            {
                UnusedText = c.ToString(CultureInfo.InvariantCulture);
                UsedText = UnusedText;
                Character = c;
            }
            VisualElement = new Run();
            SetUnused();
        }

        private string UnusedText { get; set; }
        private string UsedText { get; set; }

        public bool IsWhitespace { get; private set; }
        public char Character { get; private set; }
        public Run VisualElement { get; private set; }

        public void SetUnused()
        {
            VisualElement.Text = UnusedText;
            VisualElement.Background = null;
            VisualElement.Foreground = BlackBrush;
        }

        public void SetUsed(bool correct)
        {
            VisualElement.Text = UsedText;
            VisualElement.Background = correct ? null : RedBrush;
            VisualElement.Foreground = correct ? LightGrayBrush : WhiteBrush;
        }
    }
}