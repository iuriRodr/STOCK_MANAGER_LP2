using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Dados
{
    [Serializable]
    public class Artigos
    {
        static List<Artigo> artigos = new List<Artigo>();

        // fazer file para guardar isto
        static double spent = 0;
        static double earn = 0;


        #region PROPRIEDADES
        public static double Spent
        {
            get => spent;
            set => spent = value;
        }
        public static double Earn
        {
            get => earn;
            set => earn = value;
        }
        #endregion 


        #region METODOS
        /// <summary>
        /// Funçao que adicionar um artigo e guarda, pelos inputs do utilizador
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool InsereArtigo(Artigo a)
        {
            if (artigos.Contains(a))
            {
                return false;
            }
            a.Id = artigos.Count;
            artigos.Add(a);

            Registo r = new Registo("Comprado",a, a.Quantity);
            Registos.InsereRegisto(r);

            spent += a.Quantity * a.Retail;

            return true;
        }
        /// <summary>
        /// Funçao que mostra o artigo já adicionado
        /// </summary>
        public static void MostraArtigos()
        {
            foreach (Artigo a in artigos)
            {
                Artigo.MostraArtigo(a);
            }
            Console.WriteLine("\n\n Models Available: " + artigos.Count);
        }
        /// <summary>
        /// Funçao que percorre a lista mostrando todos os artigos usando a funçao acima
        /// </summary>
        /// <returns></returns>
        public static Artigo SearchArtigoId()
        {
            Console.WriteLine(" ID: ");
            int id = int.Parse(Console.ReadLine());
            foreach (Artigo x in artigos)
            {
                if (x.Id == id)
                {
                    return x;
                }
            }
            return null;
        }

        /// <summary>
        /// Funcao que guarda dados da lista de artigos de ficheiro binario
        /// </summary>
        //public static void SalvarDados()
        //{
        //    Stream file = File.Open("dados.bin", FileMode.Create, FileAccess.ReadWrite);
        //    BinaryFormatter bfw = new BinaryFormatter();
        //    bfw.Serialize(file, artigos);

        //    file.Close();
        //}

        ///// <summary>
        ///// Funcao que carrega dados da lista de artigos de ficheiro binario
        ///// </summary>
        //public static void CarregarDados()
        //{
        //    Stream file = File.Open("dados.bin", FileMode.Open, FileAccess.Read);
        //    BinaryFormatter b = new BinaryFormatter();
        //    if(file.Length != 0)
        //        artigos = (List<Artigo>)b.Deserialize(file);

        //    file.Close();
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        public static void ShowStats()
        {
            Console.WriteLine("Total\n----------------\nSpent: " + Spent + "\nEarn: " + Earn + "\n Profit: " + (Earn - Spent));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool RemoveArtigo(Artigo a)
        {
            if (a == null) return false;
            artigos.Remove(a);
            return true;
        }


        //Ve isto
        #region Metodos com todas as funcoes de carregar dados e salvar dados
        /// <summary>
        /// Funcao que guarda dados da lista de artigos de ficheiro binario
        /// </summary>
        public static void SalvarDadosLista()
        {
            Stream file = File.Open("dados.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, artigos);

            file.Close();
        }

        /// <summary>
        /// Funcao que carrega dados da lista de artigos de ficheiro binario
        /// </summary>
        public static void CarregarDadosLista()
        {
            Stream file = File.Open("dados.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
                artigos = (List<Artigo>)b.Deserialize(file);

            file.Close();
        }
        public static void SalvarDadosEarn()
        {
            Stream file = File.Open("dadosEarn.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, earn);

            file.Close();
        }
        public static void CarregarDadosEarn()
        {
            Stream file = File.Open("dadosEarn.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
                earn = (double)b.Deserialize(file);

            file.Close();
        }
        public static void SalvarDadosSpent()
        {
            Stream file = File.Open("dadosSpent.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, spent);

            file.Close();
        }
        public static void CarregarDadosSpent()
        {
            Stream file = File.Open("dadosSpent.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
                spent = (double)b.Deserialize(file);

            file.Close();
        }
        #endregion

        public static void SalvarDados()
        {
            Artigos.SalvarDadosLista();
            Artigos.SalvarDadosEarn();
            Artigos.SalvarDadosSpent();
            Registos.SalvarDadosRegistos();
        }

        public static void CarregarDados()
        {
            Artigos.CarregarDadosLista();
            Artigos.CarregarDadosEarn();
            Artigos.CarregarDadosSpent();
            Registos.CarregarDadosRegistos();
        }


        #endregion;

    }
}
