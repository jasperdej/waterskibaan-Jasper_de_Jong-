﻿using System;
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
            MaakWaterskibaan();
            game.RefreshGraphics += new Game.RefreshGraphicsHandler(HandleRefreshGraphics);
        }
        public void MaakWachtrijInstructie()
        {
            int counterSporters = 0;
            InstructieWachtrij.Children.Clear();
            for (int i = 0; i < wachtrijInstructieSporters.Count(); i++)
            {
                Sporter sporter = wachtrijInstructieSporters.Dequeue();
                SolidColorBrush kledingKleur = new SolidColorBrush(Color.FromRgb(sporter.KledingKleur.R, sporter.KledingKleur.G, sporter.KledingKleur.B));

                int x = 5 + (counterSporters * 12);
                int y = 5;
                if (i > 15 && i < 31)
                {
                    x -= 16;
                    y += 15;
                }
                if (i > 30 && i < 46)
                {
                    x -= 31;
                    y += 30;
                }
                if (i > 45 && i < 61)
                {
                    x -= 46;
                    y += 45;
                }
                if (i > 60 && i < 76)
                {
                    x -= 61; ;
                    y += 60;
                }
                if (i > 75 && i < 101)
                {
                    x -= 76;
                    y += 75;
                }
                int grootte = 10;
                Canvas cv = InstructieWachtrij;
                DrawSporter(kledingKleur, x, y, grootte, cv);
                counterSporters++;
                ContentLINQ.Content = $"{game.logger.GetResultaten()}";
            }
        }
        public void MaakInstructieGroep()
        {
            GroepInstructie.Children.Clear();
            for (int i = 0; i < aanwezigInstructieGroep.Count(); i++)
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
            for (int i = 0; i < wachtrijStarters.Count(); i++)
            {
                Sporter sporter = wachtrijStarters.Dequeue();
                Color kledingColor = sporter.KledingKleur;
                SolidColorBrush kledingKleur = new SolidColorBrush(Color.FromRgb(kledingColor.R, kledingColor.G, kledingColor.B));
                int x = 5 + (i * 12);
                int y = 5;
                if (counterSporters > 9 && counterSporters < 20)
                {
                    x -= 11;
                    y += 15;
                }
                int grootte = 10;
                Canvas cv = StartWachtrij;
                DrawSporter(kledingKleur, x, y, grootte, cv);
                counterSporters++;
            }
        }

        public void MaakWaterskibaan()
        {
            Waterskibaan.Children.Clear();
            Ellipse cirkel = new Ellipse
            {
                Fill = Brushes.Black,
                Width = 20,
                Height = 20,
                StrokeThickness = 2,
                Stroke = Brushes.Black
            };
            Canvas.SetLeft(cirkel, 238);
            Canvas.SetTop(cirkel, 200);
            Waterskibaan.Children.Add(cirkel);
            int[,] positiesArray = new int[10, 2] { { 107, 200 }, { 147, 127 }, { 208, 83 }, { 275, 83 }, { 328, 127 }, { 363, 200 }, { 328, 283 }, { 275, 315 }, { 208, 315 }, { 147, 283 } };
            int[,] labelArray = new int[10, 2] { { 89, 220 }, { 129, 152 }, { 190, 103 }, { 257, 108 }, { 310, 152 }, { 345, 225 }, { 310, 303 }, { 257, 335 }, { 190, 335 }, { 129, 303 } };
            //pos0 = (89,220) width is elke keer 60
            //pos1 = (129,152)
            //pos2 = (190,103)
            //pos3 = (257,108)
            //pos4 = (310,152)
            //pos5 = (345,225)
            //pos6 = (310,303)
            //pos7 = (257,335)
            //pos8 = (190,335)
            //pos9 = (129,303)
            for (int i = 0; i < 10; i++)
            {
                Random rnd = new Random();
                try
                {
                    if (game.wsb.kabel._lijnen.ElementAt(i) != null)
                    {
                        Lijn lijn = game.wsb.kabel._lijnen.ElementAt(i);
                        Sporter sporter = lijn.SporterAanLijn;
                        Color kledingColor = sporter.KledingKleur;
                        SolidColorBrush kledingKleur = new SolidColorBrush(Color.FromRgb(kledingColor.R, kledingColor.G, kledingColor.B));
                        //position0 = (107,200)
                        //position1 = (147,127)
                        //position2 = (208,83)
                        //position3 = (275,83)
                        //position4 = (328,127)
                        //position5 = (363,200)
                        //position6 = (328,283)
                        //position7 = (275,315)
                        //position8 = (208,315)
                        //position9 = (147,283)
                        DrawSporter(kledingKleur, positiesArray[i, 0], positiesArray[i, 1], 20, Waterskibaan);
                        DrawLine((positiesArray[i, 0] + 10), (positiesArray[i, 1] + 10));
                        string output = "";
                        output += $"{i} \n";
                        int randomResult = rnd.Next(1, 4);
                        if (randomResult == 2 && i != 0)
                        {
                            Sporter obj = null;
                            if (game.logger.alleBezoekers.Contains(sporter))
                            {
                                obj = game.logger.alleBezoekers.FirstOrDefault(x => x == sporter);
                            }
                            output = "";
                            int punten = sporter.Move();
                            if (punten > 5)
                            {
                                if (obj != null)
                                {
                                    game.logger.alleBezoekers.FirstOrDefault(x => x == sporter).behaaldePunten += punten;
                                }
                                sporter.behaaldePunten += punten;
                                //Draai = 20
                                //EenBeen = 70
                                //EenHand = 30
                                //Jump = 40
                                if (punten == 20)
                                {
                                    output += "Draai \n Success!";
                                }
                                else if (punten == 30)
                                {
                                    output += "Één hand \n Success!";
                                }
                                else if (punten == 40)
                                {
                                    output += "Jump \n Success!";
                                }
                                else if (punten == 70)
                                {
                                    output += "Één been \n Success!";
                                }
                                else
                                {
                                    output += "Uh oh";
                                }
                            }
                            else if (punten < 5)
                            {
                                if (punten == 1)
                                {
                                    output += "Jump \n failed";
                                }
                                else if (punten == 2)
                                {
                                    output += "Draai \n failed";
                                }
                                else if (punten == 3)
                                {
                                    output += "Één been \n failed";
                                }
                                else if (punten == 4)
                                {
                                    output += "Één hand \n failed";
                                }
                            }
                            else
                            {
                                output += "";
                            }
                        }
                        DrawText(labelArray[i, 0], labelArray[i, 1], output);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {

                }
            }
        }
        public void DrawSporter(SolidColorBrush color, int x, int y, int grootte, Canvas cv)
        {
            Ellipse cirkel = new Ellipse
            {
                Fill = color,
                Width = grootte,
                Height = grootte,
                StrokeThickness = 1,
                Stroke = Brushes.Black
            };
            Canvas.SetLeft(cirkel, x);
            Canvas.SetTop(cirkel, y);
            cv.Children.Add(cirkel);
        }
        public void DrawLine(int x1, int y1)
        {
            Line wsbLine = new Line
            {
                Stroke = Brushes.Black,
                X1 = x1,
                X2 = 248,
                Y1 = y1,
                Y2 = 210,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                StrokeThickness = 2
            };
            Waterskibaan.Children.Add(wsbLine);
        }

        public void DrawText(int x, int y, string input)
        {
            TextBlock tekst = new TextBlock
            {
                Text = input
            };
            Canvas.SetLeft(tekst, x);
            Canvas.SetTop(tekst, y);
            tekst.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            tekst.FontFamily = new FontFamily("Arial");
            Waterskibaan.Children.Add(tekst);
        }


        public void HandleRefreshGraphics(RefreshGraphicsArgs args)
        {
            Refresh();
        }


        public void Refresh()
        {
            wachtrijInstructieSporters.Clear();
            aanwezigInstructieGroep.Clear();
            wachtrijStarters.Clear();
            wachtrijInstructieSporters = new Queue<Sporter>(game.wachtrijInstructie.InstructieQueue);
            aanwezigInstructieGroep = new Queue<Sporter>(game.instructieGroep.InstructieQueue);
            wachtrijStarters = new Queue<Sporter>(game.wachtrijStarten.StartQueue);
            MaakWachtrijInstructie();
            MaakInstructieGroep();
            MaakStartWachtrij();
            MaakWaterskibaan();
            ContentLINQ.Content = "";
            LabelLijnvoorraad.Content = $"Lijnvoorraad: {game.wsb.lijnVoorraad.GetAantalLijnen()}";
            ContentLINQ.Content = $"{game.logger.GetResultaten()}";
        }
    }
}
