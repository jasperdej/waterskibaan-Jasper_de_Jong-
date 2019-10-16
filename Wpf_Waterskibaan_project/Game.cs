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
        public delegate void RefreshGraphicsHandler(RefreshGraphicsArgs args);

        public event NieuweBezoekerHandler NieuweBezoeker;
        public event InstructieAfgelopenHandler InstructieAfgelopen;
        public event LijnenVerplaatstHandler LijnenVerplaatst;
        public event RefreshGraphicsHandler RefreshGraphics;

        public virtual void RaiseNieuweBezoeker(NieuweBezoekerArgs args)
        {
            NieuweBezoekerHandler handler = NieuweBezoeker;
            handler?.Invoke(args);
        }
        public virtual void RaiseInstructieAfgelopen(InstructieAfgelopenArgs args)
        {
            InstructieAfgelopenHandler handler = InstructieAfgelopen;
            handler?.Invoke(args);
        }
        public virtual void RaiseLijnenVerplaatst(LijnenVerplaatstArgs args)
        {
            LijnenVerplaatstHandler handler = LijnenVerplaatst;
            handler?.Invoke(args);
        }
        public virtual void RaiseRefreshGraphics(RefreshGraphicsArgs args)
        {
            RefreshGraphicsHandler handler = RefreshGraphics;
            handler?.Invoke(args);
        }

        public void CreateTimer()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new System.EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }
        public void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            Loop();
            if (counter < 20)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }
        }
        public void Loop()
        {
            Zwemvest zw = new Zwemvest();
            Skies s = new Skies();
            Color kleur;
            byte r = Convert.ToByte(rnd.Next(1, 255));
            byte g = Convert.ToByte(rnd.Next(1, 255));
            byte b = Convert.ToByte(rnd.Next(1, 255));
            kleur = Color.FromRgb(r, g, b);
            Sporter sporter = new Sporter(MoveCollection.GetWillekeurigeMoves(), zw, s, kleur);
            if (counter % 3 == 0)
            {
                RaiseNieuweBezoeker(new NieuweBezoekerArgs(sporter));
            }
            else if (counter == 19)
            {
                RaiseInstructieAfgelopen(new InstructieAfgelopenArgs(7));
            }
            else if (counter % 4 == 0)
            {
                if (wachtrijStarten.StartQueue.Count() > 0 && wsb.kabel.IsStartPositieLeeg() == true)
                {
                    Sporter starter = wachtrijStarten.StartQueue.Dequeue();
                    RaiseLijnenVerplaatst(new LijnenVerplaatstArgs(starter));
                }
                else
                {
                    RaiseLijnenVerplaatst(new LijnenVerplaatstArgs());
                }
            }
            RaiseRefreshGraphics(new RefreshGraphicsArgs());
        }
    }
}
