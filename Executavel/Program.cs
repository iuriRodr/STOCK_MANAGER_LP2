using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menus;
using Dados;
/// <summary>
/// comentar tudo
/// diagrama
/// fazer files dos dois atributos + registos
/// fazer opcao de menu de ordenar alguma lista
/// </summary>
namespace BO
{
    class Program // main
    {
        static void Main(string[] args)
        {
            int op;
            Artigos.CarregarDados();

            MenuP.TextoMenu1();
            op = int.Parse(Console.ReadLine());
            MenuP.OpMenu(op);

            while (op != 0)
            {
                MenuP.TextoMenu1();
                op = int.Parse(Console.ReadLine());
                MenuP.OpMenu(op);
            }

            Artigos.SalvarDados();
        }
    }
}
