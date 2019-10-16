namespace Wpf_Waterskibaan_project
{
    public class LijnenVerplaatstArgs
    {
        public Sporter Sporter { get; set; }
        public LijnenVerplaatstArgs()
        {
            Sporter = null;
        }
        public LijnenVerplaatstArgs(Sporter sp) : this()
        {
            Sporter = sp;
        }
    }
}