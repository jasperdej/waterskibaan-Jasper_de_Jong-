using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Wpf_Waterskibaan_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game game;
        public Queue<Sporter> wachtrijInstructieSporters;
        public Queue<Sporter> aanwezigInstructieGroep;
        public Queue<Sporter> wachtrijStarters;

        public MainWindow()
        {
            InitializeComponent();
            this.Show();
            game = new Game();
            game.Initialise();
            wachtrijInstructieSporters = new Queue<Sporter>(game.wachtrijInstructie.InstructieQueue);
            aanwezigInstructieGroep = new Queue<Sporter>(game.instructieGroep.InstructieQueue);
            wachtrijStarters = new Queue<Sporter>(game.wachtrijStarten.StartQueue);
            MaakWachtrijInstructie();
            MaakInstructieGroep();
            MaakStartWachtrij();
            LabelLijnvoorraad.Content = $"Lijnvoorraad: {game.wsb.lijnVoorraad.GetAantalLijnen()}";
            game.RefreshGraphics += new Game.EventHandler(HandleRefreshGraphics);
        }
        public void MaakWachtrijInstructie()
        {
            int counterSporters = 0;
            InstructieWachtrij.Children.Clear();
            for (int i = 0; i < wachtrijInstructieSporters.Count; i++)
            {
                Sporter sporter = wachtrijInstructieSporters.Dequeue();
                Color kledingColor = sporter.KledingKleur;
                SolidColorBrush kledingKleur = new SolidColorBrush(Color.FromRgb(kledingColor.R, kledingColor.G, kledingColor.B));
                int x = 5;
                int y = 5;
                if (counterSporters < 15)
                {
                    x += (i * 12);
                }
                if (counterSporters > 15 && counterSporters < 31)
                {
                    x += ((i - 16) * 12);
                    y += 15;
                }
                else if (counterSporters > 30 && counterSporters < 46)
                {
                    x += ((i - 31) * 12);
                    y += 30;
                }else if(counterSporters > 45 && counterSporters < 61)
                {
                    x += ((i - 46) * 12);
                    y += 45;
                }else if(counterSporters > 60 && counterSporters < 76)
                {
                    x += ((i - 61) * 12);
                    y += 60;
                }else if(counterSporters > 75 && counterSporters < 101)
                {
                    x += ((i - 76) * 12);
                    y += 75;
                }
                int grootte = 10;
                Canvas cv = InstructieWachtrij;
                DrawSporter(kledingKleur, x, y, grootte, cv);
                counterSporters++;
            }
        }
        public void MaakInstructieGroep()
        {
            GroepInstructie.Children.Clear();
            for (int i = 0; i < aanwezigInstructieGroep.Count; i++)
            {
                Sporter sporter = aanwezigInstructieGroep.Dequeue();
                Color kledingColor = sporter.KledingKleur;
                SolidColorBrush kledingKleur = new SolidColorBrush(Color.FromRgb(kledingColor.R, kledingColor.G, kledingColor.B));
                int x = 10 + (i * 20);
                int y = 10;
                int grootte = 18;
                Canvas cv = GroepInstructie;
                DrawSporter(kledingKleur, x, y, grootte, cv);
            }
        }

        public void MaakStartWachtrij()
        {
            int counterSporters = 0;
            StartWachtrij.Children.Clear();
            for (int i = 0; i < wachtrijStarters.Count; i++)
            {
                Sporter sporter = wachtrijStarters.Dequeue();
                Color kledingColor = sporter.KledingKleur;
                SolidColorBrush kledingKleur = new SolidColorBrush(Color.FromRgb(kledingColor.R, kledingColor.G, kledingColor.B));
                int x = 10 + (i * 20);
                int y = 10;
                int grootte = 18;
                Canvas cv = StartWachtrij;
                DrawSporter(kledingKleur, x, y, grootte, cv);
                counterSporters++;
            }
        }
        public void DrawSporter(SolidColorBrush color, int x, int y, int grootte, Canvas cv)
        {
            Ellipse cirkel = new Ellipse
            {
                Fill = color,
                Width = grootte,
                Height = grootte
            };
            Canvas.SetLeft(cirkel, x);
            Canvas.SetTop(cirkel, y);
            cv.Children.Add(cirkel);
        }
        public void HandleRefreshGraphics(object sender, EventArgs args)
        {
            Refresh();
        }


        public void Refresh()
        {
/*            InstructieWachtrij.Children.Clear();
            GroepInstructie.Children.Clear();
            StartWachtrij.Children.Clear();*/
            wachtrijInstructieSporters = new Queue<Sporter>(game.wachtrijInstructie.InstructieQueue);
            aanwezigInstructieGroep = new Queue<Sporter>(game.instructieGroep.InstructieQueue);
            wachtrijStarters = new Queue<Sporter>(game.wachtrijStarten.StartQueue);
            MaakWachtrijInstructie();
            MaakInstructieGroep();
            MaakStartWachtrij();
            LabelLijnvoorraad.Content = $"Lijnvoorraad: {game.wsb.lijnVoorraad.GetAantalLijnen()}";
        }
    }
}
