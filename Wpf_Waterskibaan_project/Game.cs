using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Media;
using System.Windows.Threading;

namespace Wpf_Waterskibaan_project
{

    public class Game
    {
        public Waterskibaan wsb;
        Random rnd = new Random();
        int counter = 0;
        public WachtrijInstructie wachtrijInstructie;
        public InstructieGroep instructieGroep;
        public WachtrijStarten wachtrijStarten;
        public MainWindow mainWindow;

        public void Initialise()
        {
            wsb = new Waterskibaan(this);
            instructieGroep = new InstructieGroep();
            wachtrijStarten = new WachtrijStarten();
            wachtrijInstructie = new WachtrijInstructie(this, instructieGroep, wachtrijStarten);
            CreateTimer();
        }
        public delegate void NieuweBezoekerHandler(NieuweBezoekerArgs args);
        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public delegate void LijnenVerplaatstHandler(LijnenVerplaatstArgs args);
        public delegate void EventHandler(object sender, EventArgs args);

        public event NieuweBezoekerHandler NieuweBezoeker;
        public event InstructieAfgelopenHandler instructieAfgelopen;
        public event LijnenVerplaatstHandler LijnenVerplaatst;
        public event EventHandler RefreshGraphics;

        public virtual void RaiseNieuweBezoeker(NieuweBezoekerArgs args)
        {
            NieuweBezoekerHandler handler = NieuweBezoeker;
            handler?.Invoke(args);
        }
        public virtual void RaiseInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            InstructieAfgelopenHandler handler = instructieAfgelopen;
            handler?.Invoke(args);
        }
        public virtual void RaiseLijnenVerplaatst(LijnenVerplaatstArgs args)
        {
            LijnenVerplaatstHandler handler = LijnenVerplaatst;
            handler?.Invoke(args);
        }
        public virtual void RaiseRefreshGraphics(object sender, EventArgs args)
        {
            EventHandler handler = RefreshGraphics;
            handler?.Invoke(sender, args);
        }

        public void CreateTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new System.EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        public void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            loop();
            if (counter < 20) //20
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
        }
        public void loop()
        {
            Zwemvest zw = new Zwemvest();
            Skies s = new Skies();
            Color kleur;
            byte r = Convert.ToByte(rnd.Next(1, 255));
            byte g = Convert.ToByte(rnd.Next(1, 255));
            byte b = Convert.ToByte(rnd.Next(1, 255));
            kleur = Color.FromRgb(r, g, b);
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(), zw, s, kleur);
            if (counter%3 == 0) //3
            {
                RaiseNieuweBezoeker(new NieuweBezoekerArgs(sporter));
            }
            else if (counter == 19) //20
            {
                RaiseInstructieAfgelopen(new InstructieAfgelopenArgs(5));
            }else if(counter%4 == 0) //4
            {
                RaiseLijnenVerplaatst(new LijnenVerplaatstArgs(sporter));
            }
            RaiseRefreshGraphics(this, new EventArgs());
        }
    }
}
