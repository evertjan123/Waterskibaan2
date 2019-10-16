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
            if (timer == null)
            {
                SetTimer();
            }
        }
        
        public void UpdateTotaalAantalSporters()
        {
            LtotaalAantalBezoekers.Content = (from sporter
                                              in Game.logger.sporterLog
                                              select sporter).Count();
        }
        public void UpdateHoogsteScore()
        {
            var hoogsteScore = (from sporter
                    in Game.logger.sporterLog
                                orderby sporter.BehaaldePunten descending
                                select sporter.BehaaldePunten).Take(1);
            LhoogsteScore.Content = hoogsteScore.Sum();
        }
        public void UpdateRodeTruienCounter()
        {
            var kleurSporter = (from sporter
                    in Game.logger.sporterLog
                                select sporter.KledingKleur);
            int rodeKleurenCount = 0;
            foreach (System.Drawing.Color kleur in kleurSporter)
            {
                if (ColorsAreClose(kleur))
                {
                    rodeKleurenCount++;
                }
            }
            LaantalRodeKleuren.Content = rodeKleurenCount;
        }
        public void UpdateTotaalAantalRondes()
        {
            var aantalRondes = (from sporter
                   in Game.logger.sporterLog
                                let ronde = sporter.AantalRondenNogTeGaan + 1
                                select ronde);
            int rondeCount = 0;
            rondeCount = aantalRondes.Sum();
            LtotaalAantalRondjes.Content = rondeCount;
        }
        public void TekenMoveLijst()
        {
            ClijstMoves.Items.Clear();
            LinkedList<Lijn> _lijnen = new LinkedList<Lijn>();
            _lijnen = Game.kabel._lijnen;
            foreach(Lijn lijn in _lijnen)
            {
                var moves = from sporter
                            in lijn.Sporter.Moves
                            select sporter.Naam;
                if(moves.Count() > 0) {
                    foreach (string move in moves)
                    {
                        ClijstMoves.Items.Add(move);
                    }
                }
            }

        }
        public void TekenLichtsteKleuren()
        {
            int counter = 0;
            var lichtsteKleuren = (from sporter
                                   in Game.logger.sporterLog
                                   let R = sporter.KledingKleur.R
                                   let G = sporter.KledingKleur.G
                                   let B = sporter.KledingKleur.B
                                   let lichtheid = (R * R + G * G + B * B)
                                   orderby lichtheid descending
                                   select sporter).Take(10);
            foreach (Sporter sporter in lichtsteKleuren)
            {
                counter++;
                Ellipse cirkel = new Ellipse();
                System.Drawing.Color oldColor = sporter.KledingKleur;
                System.Windows.Media.Color sporterColor = System.Windows.Media.Color.FromArgb(oldColor.A, oldColor.R, oldColor.G, oldColor.B);
                cirkel.Fill = new SolidColorBrush(sporterColor);
                cirkel.Stroke = new SolidColorBrush(Colors.Black);
                cirkel.Width = 20;
                cirkel.Height = 20;
                Canvas.SetLeft(cirkel, 20 * counter);
                Canvas.SetTop(cirkel, 0);
                ClichtsteKleuren.Children.Add(cirkel);
            }
        }

        public void tekenWachtrij(Queue<Sporter> _Wachtrij, string soortRij)
        {
            int y = 0;
            int counter = 0;
            for (int i = 1; i < _Wachtrij.Count + 1; i++)
            {
                Ellipse cirkel = new Ellipse();
                System.Drawing.Color oldColor = _Wachtrij.ElementAt(i - 1).KledingKleur;
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
                counter++;
                Canvas.SetLeft(cirkel, 20 * counter);

                Canvas.SetTop(cirkel, y);
                if (soortRij == "instructie wachtrij")
                {
                    CwachtrijInstructiegroep.Children.Add(cirkel);
                }
                else if (soortRij == "instructiegroep")
                {
                    Cinstructiegroep.Children.Add(cirkel);
                }
                else
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
                int x1 = lijn.PositieOpDeKabel * 65;
                int x2 = x1 + 35;
                MaakLijn(x1, x2, lijn);
                MaakSporter(x1, lijn);
            }
        }
        public void MaakLijn(int x1, int x2, Lijn lijn)
        {
            Line line = new Line();
            Label textLijn = new Label();
            Label textMove = new Label();
            Label textPunten = new Label();
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = Colors.Black;
            textLijn.Content = lijn.PositieOpDeKabel;
            textPunten.Content = lijn.Sporter.BehaaldePunten;
            if (lijn.Sporter.HuidigeMove != null)
            {
                textMove.Content = lijn.Sporter.HuidigeMove.Naam;
                 
            }
            else
            {
                textMove.Content = "";
            }
            Canvas.SetLeft(textLijn, x1);
            Canvas.SetTop(textLijn, 55);
            Canvas.SetLeft(textMove, x1);
            Canvas.SetTop(textMove, 120);
            Canvas.SetLeft(textPunten, x1);
            Canvas.SetTop(textPunten, 140);
            line.X1 = x1;
            line.Y1 = 50;
            line.X2 = x2;
            line.Y2 = 50;
            line.Stroke = brush;
            line.StrokeThickness = 4;
            MainGame.Children.Add(line);
            MainGame.Children.Add(textLijn);
            MainGame.Children.Add(textMove);
            MainGame.Children.Add(textPunten);
        }
        public void MaakSporter(int x1, Lijn lijn)
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
            timer.Elapsed += UpdateScherm;
            timer.Elapsed += SpelRonde;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private bool ColorsAreClose(System.Drawing.Color a)
        {
            int r = (int)a.R - 240,
                g = (int)a.G - 50,
                b = (int)a.B - 50;
            return (r * r + g * g + b * b) <= 100 * 100;
        }
        public void UpdateScherm(object source, ElapsedEventArgs args)
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
                UpdateHoogsteScore();
                UpdateRodeTruienCounter();
                UpdateTotaalAantalRondes();
                UpdateTotaalAantalSporters();
                TekenLichtsteKleuren();
                TekenMoveLijst();




            });

        }
        public void SpelRonde(object source, ElapsedEventArgs args)
        {
            Game.rondeSpel();


        }
    }
}
