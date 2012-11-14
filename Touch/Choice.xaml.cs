using System;
using System.Windows;

namespace Touch
{
    /// <summary>
    /// Interaction logic for Choice.xaml
    /// </summary>
    public partial class Choice : Window
    {
        public Choice()
        {
            InitializeComponent();
        }

        private string _fj =
            @"fjfj fjfj jfjf jfjf fj jf
fjjj jfff fjfj jfjf fj jf jf fj fj jf
fjjj jfff fjfj jfjf fj jf jf fj fj jf
fjjj jfff fjfj jfjf fj jf jf fj fj jf"
                .Replace("\r\n", "\n");

        private string _dk =
            @"dkdk dkdk kdkd kdkd dk kd
dkkk kddd dkdk kdkd dk kd kd dk dk kd
dkkk kddd dkdk kdkd dk kd kd dk dk kd
dkkk kddd dkdk kdkd dk kd kd dk dk kd"
                .Replace("\r\n", "\n");

        private string _sl =
            @"slsl slsl lsls lsls sl ls
slll lsss slsl lsls sl ls ls sl sl ls
slll lsss slsl lsls sl ls ls sl sl ls
slll lsss slsl lsls sl ls ls sl sl ls"
                .Replace("\r\n", "\n");

        private string _aos =
            @"aøaø aøaø øaøa øaøa aø øa
aøøø øaaa aøaø øaøa aø øa øa aø aø øa
aøøø øaaa aøaø øaøa aø øa øa aø aø øa
aøøø øaaa aøaø øaøa aø øa øa aø aø øa"
                .Replace("\r\n", "\n");

        private string _allFingers =
            @"asdf jklø asdf jklø
fdsa ølkj fdsa ølkj
asdf jklø asdf jklø
fdsa ølkj fdsa løkj
jklø asdf jklø asdf
aj sk dl fø øf ld ks ja
ja ks ld øf fø dl sk aj"
                .Replace("\r\n", "\n");

        private string _words =
            @"ja da jada da la lala
dal kald dø klø øk ja da
øs sjø klø døs sal lakk kløs
løk søl søkk lad kladd klødd
dass dask klask laks øks".Replace("\r\n", "\n");

        private void StartFJ(object sender, RoutedEventArgs e)
        {
            var w = new MainWindow(_fj);
            w.Show();
        }

        private void StartDK(object sender, RoutedEventArgs e)
        {
            var w = new MainWindow(_dk);
            w.Show();
        }

        private void StartSL(object sender, RoutedEventArgs e)
        {
            var w = new MainWindow(_sl);
            w.Show();
        }

        private void StartAOs(object sender, RoutedEventArgs e)
        {
            var w = new MainWindow(_aos);
            w.Show();
        }

        private void StartAllFingers(object sender, RoutedEventArgs e)
        {
            var w = new MainWindow(_allFingers);
            w.Show();
        }

        private void StartWords(object sender, RoutedEventArgs e)
        {
            var w = new MainWindow(_words);
            w.Show();
        }
    }
}