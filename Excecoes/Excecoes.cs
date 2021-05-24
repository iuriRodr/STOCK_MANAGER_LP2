using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excecoes
{
    public class ExcecaoInteirosAbaixo : ApplicationException
    {
        public ExcecaoInteirosAbaixo() : base("O numero introduzido fora dos limites") { }
        public ExcecaoInteirosAbaixo(string s) : base(s) { }
        public ExcecaoInteirosAbaixo(string s, Exception e)
        {
            throw new ExcecaoInteirosAbaixo(e.Message + " - " + s);
        }
    }
}
