//Trabalho prático LP 2
//Iúri Rodrigues 21159
//Filipe Alves 19573
//
//


using System;
using Menus;
using BR;


namespace BO
{
    class Program // main
    {
        static void Main(string[] args)
        {
            int op;
            Regras.LoadAllData();

            MenuP.TextMenu1();
            op = int.Parse(Console.ReadLine());
            MenuP.OpMenu(op);

            while (op != 0)
            {
                MenuP.TextMenu1();
                op = int.Parse(Console.ReadLine());
                MenuP.OpMenu(op);
            }

            Regras.SaveAllData();

        }
    }
}
