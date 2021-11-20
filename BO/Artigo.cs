//Trabalho prático LP 2
//Iúri Rodrigues 21159
//
//
//

using System;
using Excecoes;
using Dados;

namespace BO
{
    public enum TYPE { Tee, Hoodie, Sneaker, Acessorie };
  

    [Serializable]
    public class Artigo
    {
        #region ATRIBUTOS
        int id;
        TYPE type;
        string brand;
        string model;
        string size;
        double retail;
        double resell;
        int quantity;
        double profit;
        #endregion

        #region CONSTRUTORES
        public Artigo()
        { }
        #endregion

        #region PROPRIEDADES
        public int Id
        {
            get => id;
            set => id = value;
        }
        public TYPE Type
        {
            get => type;
            set => type = value;
        }
        public string Brand
        {
            get => brand;
            set => brand = value;
        }
        public string Model
        {
            get => model;
            set => model = value;
        }
        public string Size
        {
            get => size;
            set => size = value;
        }
        public double Retail
        {
            get => retail;
            set => retail = value;
        }
        public double Resell
        {
            get => resell;
            set => resell = value;
        }
        public int Quantity
        {
            get => quantity;
            set => quantity = value;
        }
        public double Profit
        {
            get => profit;
            set => profit = value;
        }
        //public ESTADO Estado
        //{

        //}
        #endregion

        #region METODOS
        /// <summary>
        /// Adiciona um artigo á lista
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns> o artigo adicionado

        public static Artigo AddArtigo(Artigo a)
            {
                Console.WriteLine("\nType your choice:");
                Console.WriteLine("\n1- Acessorie / 2-Hoodie / 3-Sneaker / 4-TEE\n");
                int typeshow = int.Parse(Console.ReadLine());
                if (typeshow < 1 || typeshow > 4) throw new ExceptionInt();


                switch (typeshow) 
                {
                    case 1:
                        a.Type = TYPE.Acessorie;
                        break;

                    case 2:
                        a.Type = TYPE.Hoodie;
                        break;

                    case 3:
                        a.Type = TYPE.Sneaker;
                        break;

                    case 4:
                        a.Type = TYPE.Tee;
                        break;

                    default:
                        throw new ApplicationException("Invalid input.");
                }

                Console.WriteLine("\nBrand : ");
                a.Brand = Console.ReadLine();

                Console.WriteLine("\nModel : ");
                a.Model = Console.ReadLine();

                Console.WriteLine("\nSize : ");
                a.Size = Console.ReadLine(); 
            
                bool teste = false;
                do
                {
                    int aux;
                    Console.WriteLine("\nRetail : ");
                    string aux4 = Console.ReadLine();
                    if (int.TryParse(aux4, out aux))
                    {
                        if (aux >= 0)
                        {
                            teste = true;
                            a.Retail = aux;
                        }
                    }
                } while (teste == false);


                bool teste2 = false;
                do
                {
                    int aux;
                    Console.WriteLine("\nResell : ");
                    string aux4 = Console.ReadLine();
                    if (int.TryParse(aux4, out aux))
                    {
                        if (aux >= 0)
                        {
                            teste2 = true;
                            a.Resell = aux;
                        }
                    }
                } while (teste2 == false);

                bool teste3 = false;
                do
                {
                    int aux;
                    Console.WriteLine("\nQuantity : ");
                    string aux4 = Console.ReadLine();
                    if (int.TryParse(aux4, out aux))
                    {
                        if (aux >= 0)
                        {
                            teste3 = true;
                            a.Quantity = aux;
                        }
                    }
                } while (teste3 == false);

                return a;
            }

        /// <summary>
        /// Funçao que mostra o artigos em stock
        /// </summary>
        /// <param name="artigo"></param>
        public static void ShowArtigo(Artigo artigo)
        {
            Console.WriteLine("- - - - - - - - - - - - - -");
            Console.WriteLine("Id : " + artigo.Id);
            Console.WriteLine("Product Type : " + artigo.Type);
            Console.WriteLine("Brand : " + artigo.Brand);
            Console.WriteLine("Model : " + artigo.Model);
            Console.WriteLine("Size : " + artigo.Size);
            Console.WriteLine("Quantity:" + artigo.Quantity);
            Console.WriteLine("Retail : " + artigo.Retail);
            Console.WriteLine("Resell : " + artigo.Resell);
            Console.WriteLine("- - - - - - - - - - - - - -");

        }
        /// <summary>
        /// Funçao que procura um artigo através do seu id
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool EditArtigo(Artigo a)
        {
            int op;
            Console.WriteLine(" 1 - Product Type");
            Console.WriteLine(" 2 - Brand");
            Console.WriteLine(" 3 - Model");
            Console.WriteLine(" 4 - Size");
            Console.WriteLine(" 5 - Quantity");
            Console.WriteLine(" 6 - Retail");
            Console.WriteLine(" 7 - Resell");
            op = int.Parse(Console.ReadLine());


            switch (op)
            {
                case 1:
                    Console.WriteLine("\nType: ");
                    Console.WriteLine("\n1- Acessorie / 2-Hoodie / 3-Sneaker / 4-TEE\n");
                    int typeshow = int.Parse(Console.ReadLine());
                    if (typeshow < 1 || typeshow > 4) throw new ExceptionInt();
                    switch (typeshow)
                    {
                        case 1:
                            a.Type = TYPE.Acessorie;
                            break;

                        case 2:
                            a.Type = TYPE.Hoodie;
                            break;

                        case 3:
                            a.Type = TYPE.Sneaker;
                            break;

                        case 4:
                            a.Type = TYPE.Tee;
                            break;

                        default:
                            throw new ApplicationException("Invalid input."); // exceçao quando utilizador nao usa as opçºoes válidas

                    }
                    break;

                case 2:
                    Console.WriteLine("\nBrand : ");
                    a.Brand = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("\nModel : ");
                    a.Model = Console.ReadLine();
                    break;
                case 4:

                    Console.WriteLine("\nSize : ");
                    a.Size = Console.ReadLine();
                    break;

                case 5:
                    bool teste = false;
                    do
                    {
                        int aux;
                        Console.WriteLine("\nQuantity : ");
                        string aux1 = Console.ReadLine();
                        if (int.TryParse(aux1, out aux))
                        {
                            if (aux >= 0)
                            {
                                teste = true;
                                a.Quantity = aux;
                            }
                        }
                    } while (teste == false);
                    break;

                   
                case 6:
                    bool teste1 = false;
                    do
                    {
                        int aux;
                        Console.WriteLine("\nRetail : ");
                        string aux1 = Console.ReadLine();
                        if (int.TryParse(aux1, out aux))
                        {
                            if (aux >= 0)
                            {
                                teste1 = true;
                                a.Retail = aux;
                            }
                        }
                    } while (teste1 == false);
                    break;

                case 7:
                    bool teste2 = false;
                    do
                    {
                        int aux;
                        Console.WriteLine("\nResell : ");
                        string aux1 = Console.ReadLine();
                        if (int.TryParse(aux1, out aux))
                        {
                            if (aux >= 0)
                            {
                                teste2 = true;
                                a.Resell = aux;
                            }
                        }
                    } while (teste2 == false);
                    break;

                default:
                    Console.WriteLine("Option invalid");
                    break;
            }
            return true;


        }
        /// <summary>
        /// Funçao que vende o artigo, se o stock ao fim da venda for 0, é removido da lista de artigos
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool Sell(Artigo a)
        {
            Console.WriteLine("Quantity Available: " + a.Quantity);
            Console.WriteLine("Quatity To Sell: ");
            int x = int.Parse(Console.ReadLine());
            if (x < 0) throw new Exception("Invalid imput (must be >0)");

            if (x > a.Quantity) return false;

            a.Quantity -= x;
            Console.WriteLine("\nItem Sold");
            Registo r = new Registo("Sold", a, x);
            Registos.InsertRecord(r);

            Artigos.Earn += x * a.Resell;

            if (a.Quantity == 0)
            {
                if (Artigos.RemoveArtigo(a) == true) Console.WriteLine("Sold, Out of stock");
                else Console.WriteLine("Something went wrong!!!");
            }

            return true;
        }


        #endregion

    }



}
