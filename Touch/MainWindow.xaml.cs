using System;
using System.Media;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Touch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Brush RedBrush = new SolidColorBrush(Colors.Red);
        private static readonly Brush OrangeBrush = new SolidColorBrush(Colors.Orange);
        private static readonly Brush GreenBrush = new SolidColorBrush(Colors.Green);

        private int _cursorIndex;
        private readonly Symbol[] _symbols;

        private bool _started;
        private DateTime _startTime;
        private bool _completed;

        public MainWindow(string text)
        {
            InitializeComponent();

            var p = new Paragraph();
            _symbols = new Symbol[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                var s = new Symbol(text[i]);
                _symbols[i] = s;
                p.Inlines.Add(s.VisualElement);
            }
            TouchText.Document.Blocks.Add(p);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (_completed)
            {
                return;
            }
            if (e.Key == Key.Back)
            {
                if (_cursorIndex > 0)
                {
                    _cursorIndex -= 1;
                    _symbols[_cursorIndex].SetUnused();
                }
                return;
            }

            if (_cursorIndex >= _symbols.Length)
            {
                Console.Beep();
                return;
            }

            Time();
            char key = e.Key == Key.Space || e.Key == Key.Enter
                           ? ' '
                           : KeyHelper.GetCharFromKey(e.Key);
            if (key == char.MinValue)
            {
                return;
            }

            Symbol s = _symbols[_cursorIndex];
            bool correct = key == s.Character;
            s.SetUsed(correct);
            _cursorIndex += 1;
            if (correct && _cursorIndex >= _symbols.Length)
            {
                _completed = true;
            }
        }

        private void Time()
        {
            if (!_started)
            {
                _started = true;
                _startTime = DateTime.UtcNow;
                return;
            }

            TimeSpan used = DateTime.UtcNow - _startTime;
            double cpm = _cursorIndex / (used.TotalSeconds / 60);

            Speed.Content = cpm.ToString("0");

            const double minSpeed = 40;
            const double okSpeed = 100;
            const double goodSpeed = 200;

            double indicator = Math.Max(minSpeed, Math.Min(cpm, goodSpeed));
            Row0.Height = new GridLength(goodSpeed - indicator, GridUnitType.Star);
            Row1.Height = new GridLength(indicator, GridUnitType.Star);

            var brush = cpm < minSpeed ? RedBrush : (cpm < okSpeed ? OrangeBrush : GreenBrush);
            Indicator.Background = brush;
        }
    }
}