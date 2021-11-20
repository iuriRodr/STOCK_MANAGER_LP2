//Trabalho prático LP 2
//Iúri Rodrigues 21159
//
//
//

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
        public static void SalvarDados()
        {
            Stream file = File.Open("dados.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, artigos);

            file.Close();
        }

        /// <summary>
        /// Funcao que carrega dados da lista de artigos de ficheiro binario
        /// </summary>
        public static void CarregarDados()
        {
            Stream file = File.Open("dados.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if(file.Length != 0)
                artigos = (List<Artigo>)b.Deserialize(file);

            file.Close();
        }

        #endregion;

    }
}
