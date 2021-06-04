//Trabalho prático LP 2
//Iúri Rodrigues 21159
//Filipe Alves 19573
//
//


using System;
using System.Collections.Generic;
using BO;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dados
{
    
    [Serializable] 
    public class Registo
    {
        string info;
        string state;
        double resell;
        double retail;
        int quantity;
        DateTime date;


        #region Construtor

        public Registo(string state, Artigo a, int quantity) 
        {
            this.info = a.Brand + a.Model;
            this.state = state;
            this.resell = a.Resell;
            this.retail = a.Retail;
            this.quantity = quantity;
            date = DateTime.Now;

        }

        #endregion

        #region Propriedades

        public string Info
        {
            get => info;
            set => info = value;
        }
        public string State
        {
            get => state;
            set => state = value;
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

        public DateTime Date
        {
            get => date;
            set => date = value;
        }
        #endregion


      
    }

    public class Registos
    {
        static List<Registo> registos = new List<Registo>();

        #region Construtor

        public Registos()
        {

        }

        #endregion


        /// <summary>
        /// Funçao que insere um registo de um artigo
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static bool InsertRecord(Registo r)
        {
            if (registos.Contains(r) || r == null)
            {
                return false;
            }
            registos.Add(r);
            return true;
        }


        /// <summary>
        /// Funçao que percorre a lista e mostra todos os registos usando a funçao (Registo.ShowRecord)
        /// </summary>
        public static List<Registo> ShowRecords()
        {
            List<Registo> temp = new List<Registo>(registos);
            return temp;
        }


        /// <summary>
        /// Funçao que Salva os dados de resgistos em ficheiro binario
        /// </summary>
        public static void SaveDataRecord()
        {
            Stream file = File.Open("dadosRegistos.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, registos);

            file.Close();
        }

        /// <summary>
        /// Funçao que carrega os registos de um ficheiro binario
        /// </summary>
        public static void LoadDataRecord()
        {
            Stream file = File.Open("dadosRegistos.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
                registos = (List<Registo>)b.Deserialize(file);

            file.Close();
        }

       
    }
}
