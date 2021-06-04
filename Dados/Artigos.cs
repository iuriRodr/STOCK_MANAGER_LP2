//Trabalho prático LP 2
//Iúri Rodrigues 21159
//Filipe Alves 19573
//
//


using System;
using System.Collections.Generic;
using BO;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Dados
{
    [Serializable]
    public class Artigos
    {
        static List<Artigo> artigos = new List<Artigo>();

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
        /// Funçao que verifica se já existe o artigo e se não existir adicionar um artigo e guarda, pelos inputs do utilizador
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool InsertArtigo(Artigo a)
        {
            if (artigos.Contains(a))
            {
                return false;
            }
            a.Id = artigos.Count;
            artigos.Add(a);

            Registo r = new Registo("Added",a, a.Quantity);
            Registos.InsertRecord(r);

            spent += a.Quantity * a.Retail;

            return true;
        }

        /// <summary>
        /// Funçao que percorre a lista mostrando todos os artigos usando a funçao acima
        /// </summary>
        public static void ShowArtigos()
        {
            foreach (Artigo a in artigos)
            {
                Artigo.ShowArtigo(a);
            }
            //Console.WriteLine("\n\n Models Available: " + artigos.Count);
        }

        /// <summary>
        /// Funçao que perocura um artigo na lista pelo seu ID
        /// </summary>
        /// <returns></returns>
        public static Artigo SearchArtigoId(int id)
        {
            foreach (Artigo x in artigos)
            {
                if (x.Id == id)
                {
                    return x;
                }
            }
            return null;
        }

        //}
        ///// <summary>
        ///// Funçao que mostra as estatisticas das vendas ( o total gasto, o total vendido e o lucro)
        ///// </summary>
        public static List<double> ShowStats()
        {
            List<double> stats = new List<double>();
            stats.Add(spent);
            stats.Add(Earn);
            return stats;
            
        }

        /// <summary>
        /// Funçao que remove um artigo da lista
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool RemoveArtigo(Artigo a)
        {
            if (a == null) return false;
            artigos.Remove(a);
            return true;
        }


        
        #region Funcoes de carregar dados e salvar dados
        /// <summary>
        /// Funcao que guarda dados da lista de artigos em ficheiro binario
        /// </summary>
        public static void SaveDataList()
        {
            Stream file = File.Open("dados.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, artigos);

            file.Close();
        }

        /// <summary>
        /// Funcao que carrega dados da lista de artigos de ficheiro binario
        /// </summary>
        public static void LoadDataList()
        {
            Stream file = File.Open("dados.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
                artigos = (List<Artigo>)b.Deserialize(file);

            file.Close();
        }

        /// <summary>
        /// Funcao que guarda o total vendido de artigos em ficheiro binario
        /// </summary>
        public static void SaveDataEarn()
        {
            Stream file = File.Open("dadosEarn.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, earn);

            file.Close();
        }

        /// <summary>
        /// Funcao que carrega o total vendido de artigos de um ficheiro binario
        /// </summary>
        public static void LoadDataEarn()
        {
            Stream file = File.Open("dadosEarn.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
                earn = (double)b.Deserialize(file);

            file.Close();
        }

        /// <summary>
        /// Funcao que guarda o total gasto em  ficheiro binario
        /// </summary>
        public static void SaveDataSpent()
        {
            Stream file = File.Open("dadosSpent.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, spent);

            file.Close();
        }

        /// <summary>
        /// Funcao que carrega o total gasto de um ficheiro binario
        /// </summary>
        public static void LoadDataSpent()
        {
            Stream file = File.Open("dadosSpent.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
                spent = (double)b.Deserialize(file);

            file.Close();
        }
        #endregion


        /// <summary>
        /// Funcao que chama todas as funçoes que salvam dados em ficheiros
        /// </summary>
        public static void SaveData()
        {
            SaveDataList();
            SaveDataEarn();
            SaveDataSpent();
            Registos.SaveDataRecord();
        }


        /// <summary>
        /// Funçao que chama todas as funçoes que carregam dados 
        /// </summary>
        public static void LoadData()
        {
            LoadDataList();
            LoadDataEarn();
            LoadDataSpent();
            Registos.LoadDataRecord();
        }


        #endregion;

    }
}
