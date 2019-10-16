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
        public MainWindow(Game game)
        {
            Queue<Sporter> wachtrijInstructieSporters;
            InitializeComponent();
            wachtrijInstructieSporters = new Queue<Sporter>(game.wachtrijInstructie.InstructieQueue);
            for(int i = 0; i<wachtrijInstructieSporters.Count; i++)
            {
                Sporter sporter = wachtrijInstructieSporters.Dequeue();
                Color kledingColor = sporter.KledingKleur;
                Ellipse cirkel = new Ellipse();
                cirkel.Fill = new SolidColorBrush(Color.FromRgb(kledingColor.R, kledingColor.G, kledingColor.B));
                cirkel.Width = 18;
                cirkel.Height = 18;
                Canvas.SetLeft(cirkel, 10);
                Canvas.SetTop(cirkel, 10);
                Canvas.Add(cirkel); //canvas meegeven in functie als cv
                //zet maken van vorm in aparte functie met x, y, canvas, kleur etc.

            }
        }
    }
}
