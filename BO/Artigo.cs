using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Artigo AddArtigo(Artigo a)
            {
                Console.WriteLine("\nType your choice 1:");
                Console.WriteLine("\n1- Acessorie / 2-Hoodie / 3-Sneaker / 4-TEE\n");
                int typeshow = int.Parse(Console.ReadLine());
                if (typeshow < 1 || typeshow > 4) throw new ExcecaoInteirosAbaixo();


                switch (typeshow)  // adicionar enum TYPE
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

                Console.WriteLine("\nRetail : ");
                a.Retail = double.Parse(Console.ReadLine());
                if (a.Retail < 0) throw new Exception("Input menor que 0");

                Console.WriteLine("\nResell : ");
                a.Resell = double.Parse(Console.ReadLine());
                if (a.Resell < 0) throw new ExcecaoInteirosAbaixo();

                Console.WriteLine("\nQuantity : ");
                a.Quantity = Int32.Parse(Console.ReadLine());
                if (a.Quantity < 0) throw new ExcecaoInteirosAbaixo();

            return a;
        }
        /// <summary>
        /// Funçao que verifica se já existe o artigo, se nao existir adiciona
        /// </summary>
        /// <param name="artigo"></param>
        public static void MostraArtigo(Artigo artigo)
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
            Console.WriteLine("- - - - -  STATS -  - - - -");
            Console.WriteLine("Profit : " + artigo.Profit);
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

                    Console.WriteLine("\nQuantity : ");
                    a.Quantity = int.Parse(Console.ReadLine());
                    break;

                case 6:
                    Console.WriteLine("\nRetail : ");
                    a.Retail = double.Parse(Console.ReadLine());
                    break;

                case 7:
                    Console.WriteLine("\nResell : ");
                    a.Resell = double.Parse(Console.ReadLine());
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
            return true;


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool Sell(Artigo a)
        {
            Console.WriteLine("Quantidade disponivel: " + a.Quantity);
            Console.WriteLine("Quantos deseja vender: ");
            int x = int.Parse(Console.ReadLine());

            if (x > a.Quantity) return false;

            a.Quantity -= x;
            Registo r = new Registo("Vendido", a, x);
            Registos.InsereRegisto(r);

            Artigos.Earn += x * a.Resell;

            if (a.Quantity == 0)
            {
                if (Artigos.RemoveArtigo(a) == true) Console.WriteLine("Artigo removido");
                else Console.WriteLine("Erro ao remover artigo!!!");
            }

            return true;
        }


        #endregion

    }



}
