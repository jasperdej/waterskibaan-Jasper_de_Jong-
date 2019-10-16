using System;
using System.Collections;
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

namespace Wpf_Waterskibaan_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game game = new Game();
        public Queue<Sporter> wachtrijInstructieSporters;
        public Queue<Sporter> aanwezigInstructieGroep;
        public Queue<Sporter> wachtrijStarters;
        
        public MainWindow()
        {
            InitializeComponent();
            wachtrijInstructieSporters = new Queue<Sporter>(game.wachtrijInstructie.InstructieQueue);
            aanwezigInstructieGroep = new Queue<Sporter>(game.instructieGroep.InstructieQueue);
            wachtrijStarters = new Queue<Sporter>(game.wachtrijStarten.StartQueue);
            MaakWachtrijInstructie();
            MaakInstructieGroep();
            MaakStartWachtrij();
        }
        public void MaakWachtrijInstructie()
        {
            for (int i = 0; i < wachtrijInstructieSporters.Count; i++)
            {
                Sporter sporter = wachtrijInstructieSporters.Dequeue();
                Color kledingColor = sporter.KledingKleur;
                SolidColorBrush kledingKleur = new SolidColorBrush(Color.FromRgb(kledingColor.R, kledingColor.G, kledingColor.B));
                int x = 0 + (i * 20);
                int y = 10;
                int grootte = 18;
                Canvas cv = InstructieWachtrij;
                DrawSporter(kledingKleur, x, y, grootte, cv);
            }
        }
        public void MaakInstructieGroep()
        {
            for (int i = 0; i < aanwezigInstructieGroep.Count; i++)
            {
                Sporter sporter = aanwezigInstructieGroep.Dequeue();
                Color kledingColor = sporter.KledingKleur;
                SolidColorBrush kledingKleur = new SolidColorBrush(Color.FromRgb(kledingColor.R, kledingColor.G, kledingColor.B));
                int x = 0 + (i * 20);
                int y = 10;
                int grootte = 18;
                Canvas cv = GroepInstructie;
                DrawSporter(kledingKleur, x, y, grootte, cv);
            }
        }

        public void MaakStartWachtrij()
        {
            for (int i = 0; i < wachtrijStarters.Count; i++)
            {
                Sporter sporter = wachtrijStarters.Dequeue();
                Color kledingColor = sporter.KledingKleur;
                SolidColorBrush kledingKleur = new SolidColorBrush(Color.FromRgb(kledingColor.R, kledingColor.G, kledingColor.B));
                int x = 0 + (i * 20);
                int y = 10;
                int grootte = 18;
                Canvas cv = StartWachtrij;
                DrawSporter(kledingKleur, x, y, grootte, cv);
            }
        }
        public void DrawSporter(SolidColorBrush color, int x, int y, int grootte, Canvas cv)
        {
            Ellipse cirkel = new Ellipse();
            cirkel.Fill = color;
            cirkel.Width = grootte;
            cirkel.Height = grootte;
            Canvas.SetLeft(cirkel, x);
            Canvas.SetTop(cirkel, y);
            cv.Children.Add(cirkel);
        }

        public void Refresh()
        {

        }
    }
}
