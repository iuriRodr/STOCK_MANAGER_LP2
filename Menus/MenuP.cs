//Trabalho prático LP 2
//Iúri Rodrigues 21159
//Filipe Alves 19573
//
//

using System;
using BO;
using BR;
using Excecoes;
using Dados;
using System.Collections.Generic;

namespace Menus
{
    public class MenuP
    {
        /// <summary>
        /// Funçao que apresenta o menu inicial ao utilizador
        /// </summary>
        public static void TextMenu1()
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
            Console.WriteLine("\nOption: ");
        }

        /// <summary>
        /// Menu Inicial e as suas opçoes com as respetivas funcionalidades
        /// 
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
                        a = Regras.AddArt(a);

                        if (a != null) Regras.InsertArt(a);
                        Console.Clear();
                        break;

                    case 2:
                        Console.Clear();
                        a = Regras.Search();
                        Console.Clear();
                        if (a != null)
                        {
                            Regras.EditArtt(a);
                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                        Console.Clear();
                        break;

                    case 3:
                        Console.Clear();
                        Regras.ShowArt();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        //Regras.ShowStat(a);
                        Console.WriteLine("Total\n----------------\nSpent: " + Artigos.Spent + "\nEarn: " + Artigos.Earn + "\n Profit: " + (Artigos.Earn - Artigos.Spent));
                      
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 5:
                        Console.Clear();
                        List<Registo> aux = new List<Registo>(Regras.ShowRecord());
                        foreach (Registo r in Regras.ShowRecord())
                        {
                                Console.WriteLine("- - - - - - - - - - - - - -");
                                Console.WriteLine("Info : " + r.Info);
                                Console.WriteLine("State : " + r.State);
                                Console.WriteLine("Resell : " + r.Resell);
                                Console.WriteLine("Retail : " + r.Retail);
                                Console.WriteLine("Quantity : " + r.Quantity);
                                Console.WriteLine("Date : " + r.Date);
                                Console.WriteLine("- - - - - - - - - - - - - -");
                        }
                        //Regras.ShowRecord();
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        Console.Clear();
                        a = Regras.Search();
                        Console.Clear();
                        if (a != null)
                        {
                            Regras.SellArt(a);
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
            catch (ExceptionInt e)
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
