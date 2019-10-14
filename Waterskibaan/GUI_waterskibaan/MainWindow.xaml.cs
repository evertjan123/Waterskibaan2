using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using Waterskibaan;

namespace GUI_waterskibaan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;
        public MainWindow()
        {
            InitializeComponent();
            Game Game = new Game();
            game = Game;

        }

        private void StartSpel(object sender, RoutedEventArgs e)
        {
            spel();

        }

        private void StopSpel(object sender, ContextMenuEventArgs e)
        {
            MainGame.Children.Clear();
        }

        public void tekenLijnen()
        {
            LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();
            _lijnen = game.w.ReturnKabel()._lijnen;
            foreach (Lijn lijn in _lijnen)
            {
                int x1 = lijn.PositieOpDeKabel * 50;
                int x2 = x1 + 35;
                maakLijn(x1, x2, lijn.PositieOpDeKabel);
            }
        }
        public void maakLijn(int x1, int x2, int nummer)
        {
            Line line = new Line();
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Black;
            Label textbox = new Label();
            textbox.Content = nummer.ToString();
            Canvas.SetLeft(textbox, x1);
            Canvas.SetTop(textbox, 55);
            line.X1 = x1;
            line.Y1 = 50;
            line.X2 = x2;
            line.Y2 = 50;
            line.Stroke = brush;
            line.StrokeThickness = 4;
            MainGame.Children.Add(line);
            MainGame.Children.Add(textbox);
        }
        public void spel()
        {
            game.w.SporterStart(new Sporter());
            game.w.VerplaatsKabel();
            tekenLijnen();
            Thread.Sleep(1000);
            game.w.SporterStart(new Sporter());
            game.w.VerplaatsKabel();
            tekenLijnen();
            MainGame.UpdateLayout();
            Thread.Sleep(1000);
            game.w.SporterStart(new Sporter());
            game.w.VerplaatsKabel();
            tekenLijnen();
   
            Thread.Sleep(1000);

        }
    }
}
