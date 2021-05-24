using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using Dados;
using Excecoes;

namespace Menus
{
    public class MenuP
    {
        /// <summary>
        /// 
        /// </summary>
        public static void TextoMenu1()
        {
            Console.WriteLine(" Choose: ");
            Console.WriteLine("\n1 - Add ");
            Console.WriteLine("\n2 - Edit");
            Console.WriteLine("\n3 - Show Stock");
            Console.WriteLine("\n4 - Stats");
            Console.WriteLine("\n5 - Records");
            Console.WriteLine("\n6 - Sell");
            Console.WriteLine("\n0 - Exit");
            Console.WriteLine("\n- - - - - - - - - - - - - - - - -");
            Console.WriteLine("\nOpcion: ");
        }
        /// <summary>
        /// Menu Inicial
        /// </summary>
        /// <param name="op"></param>
        public static void OpMenu(int op)
        {

            Artigo a = new Artigo();
            try
            {
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        a = Artigo.AddArtigo(a);


                        if (a != null) Artigos.InsereArtigo(a);
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        a = Artigos.SearchArtigoId();
                        Console.Clear();
                        if (a != null)
                        {
                            Artigo.EditArtigo(a);
                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        Artigos.MostraArtigos();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        Artigos.ShowStats();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        Console.Clear();
                        Registos.MostraRegistos();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        Console.Clear();
                        a = Artigos.SearchArtigoId();
                        Console.Clear();
                        if (a != null)
                        {
                            Artigo.Sell(a);
                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;


                    case 0:
                        Console.Clear();
                        Console.WriteLine("SEE YA ...");
                        Console.ReadKey();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("INVALID OPCION");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            catch (ExcecaoInteirosAbaixo e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.Clear();
            }
            catch (ApplicationException e1)
            {
                Console.Clear();
                Console.WriteLine(e1.Message);
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
