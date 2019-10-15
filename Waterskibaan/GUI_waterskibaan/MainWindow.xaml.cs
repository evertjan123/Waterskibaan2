using System;
using System.Drawing;
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
using System.Timers;
using Waterskibaan;

namespace GUI_waterskibaan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        Game Game = new Game();
        private Timer timer;

        public MainWindow()
        {
            InitializeComponent();
            Game.Initialize();





        }

        private void StartSpel(object sender, RoutedEventArgs e)
        {
            SetTimer();
        }

        public void tekenWachtrij(Queue<Sporter> _Wachtrij, string soortRij)
        {
            int y = 0;
            int counter = 0;
            for (int i = 1; i < _Wachtrij.Count+1; i++)
            {
                counter++;
                Ellipse cirkel = new Ellipse();
                System.Drawing.Color oldColor = _Wachtrij.ElementAt(i-1).KledingKleur;
                System.Windows.Media.Color sporterColor = System.Windows.Media.Color.FromArgb(oldColor.A, oldColor.R, oldColor.G, oldColor.B);
                cirkel.Fill = new SolidColorBrush(sporterColor);
                cirkel.Stroke = new SolidColorBrush(Colors.Black);
                cirkel.Width = 20;
                cirkel.Height = 20;
                if (i % 5 == 0)
                {
                    y += 35;
                    counter = 0;
                }
                Canvas.SetLeft(cirkel, 20 * counter );

                Canvas.SetTop(cirkel, y);
                if(soortRij == "instructie wachtrij")
                {
                    CwachtrijInstructiegroep.Children.Add(cirkel);
                } else if(soortRij == "instructiegroep")
                {
                    Cinstructiegroep.Children.Add(cirkel);
                } else
                {
                    CwachtrijStarten.Children.Add(cirkel);
                }
            }
        }
        public void tekenMainScherm()
        {
            LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();
            _lijnen = Game.kabel._lijnen;
            foreach (Lijn lijn in _lijnen)
            {
                int x1 = lijn.PositieOpDeKabel * 50;
                int x2 = x1 + 35;
                maakLijn(x1, x2, lijn.PositieOpDeKabel);
                maakSporter(x1, lijn);
            }
        }
        public void maakLijn(int x1, int x2, int nummer)
        {
            
                Line line = new Line();
                Label textbox = new Label();
                SolidColorBrush brush = new SolidColorBrush();
                brush.Color = Colors.Black;
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
        public void maakSporter(int x1, Lijn lijn)
        {
            Ellipse cirkel = new Ellipse();
            System.Drawing.Color oldColor = lijn.Sporter.KledingKleur;
            System.Windows.Media.Color sporterColor = System.Windows.Media.Color.FromArgb(oldColor.A, oldColor.R, oldColor.G, oldColor.B);
            cirkel.Fill = new SolidColorBrush(sporterColor);
            cirkel.Stroke = new SolidColorBrush(Colors.Black);
            cirkel.Width = 40;
            cirkel.Height = 40;
            Canvas.SetLeft(cirkel, x1);
            Canvas.SetTop(cirkel, 70);
            MainGame.Children.Add(cirkel);
        }
        private void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += updateScherm;
            timer.Elapsed += spelRonde;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private void stopTimer()
        {
            timer.Stop();
            timer.Dispose();

        }
        public void updateScherm(object source, ElapsedEventArgs args)
        {

            this.Dispatcher.Invoke(() =>
            {
                MainGame.Children.Clear();
                CwachtrijInstructiegroep.Children.Clear();
                CwachtrijStarten.Children.Clear();
                Cinstructiegroep.Children.Clear();
                tekenMainScherm();
                tekenWachtrij(Game.wachtrijintstructie.ReturnWachtrij(), "instructie wachtrij");
                tekenWachtrij(Game.instructieGroep.ReturnWachtrij(), "instructiegroep");
                tekenWachtrij(Game.WachtrijStarten.ReturnWachtrij(), "starten wachtrij");
                LvoorraadLijnen.Content = Game.w.lv.GetAantalLijnen();
                
            });

        }
        public void spelRonde(object source, ElapsedEventArgs args)
        {
            Game.rondeSpel();


        }
    }
}
