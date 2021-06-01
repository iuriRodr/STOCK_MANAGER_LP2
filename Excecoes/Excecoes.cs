//Trabalho prático LP 2
//Iúri Rodrigues 21159
//Filipe Alves 19573
//
//


using System;


namespace Excecoes
{

    public class ExceptionInt : ApplicationException
    {
        public ExceptionInt() : base("Number out of limits") { }
        public ExceptionInt(string s) : base(s) { }
        public ExceptionInt(string s, Exception e)
        {
            throw new ExceptionInt(e.Message + " - " + s);
        }
    }
}
