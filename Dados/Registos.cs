using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dados
{
    
    [Serializable] 
    public class Registo
    {
        string info;
        string estado;
        double resell;
        double retail;
        int quantity;
        DateTime date;


        #region Construtor

        public Registo(string estado, Artigo a, int quantity) 
        {
            this.info = a.Brand + a.Model;
            this.estado = estado;
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
        public string Estado
        {
            get => estado;
            set => estado = value;
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

        public DateTime Date
        {
            get => date;
            set => date = value;
        }
        #endregion

        public static void MostrarRegisto(Registo r)
        {
            Console.WriteLine("- - - - - - - - - - - - - -");
            Console.WriteLine("Info : " + r.Info);
            Console.WriteLine("Estado : " + r.Estado);
            Console.WriteLine("Resell : " + r.Resell);
            Console.WriteLine("Retail : " + r.Retail);
            Console.WriteLine("Quantity : " + r.quantity);
            Console.WriteLine("Date : " + r.Date);
            Console.WriteLine("- - - - - - - - - - - - - -");

        }
    }

    public class Registos
    {
        static List<Registo> registos = new List<Registo>();

        #region Construtor

        public Registos()
        {

        }

        #endregion

        public static bool InsereRegisto(Registo r)
        {
            if (registos.Contains(r) || r == null)
            {
                return false;
            }
            registos.Add(r);
            return true;
        }

        public static void MostraRegistos()
        {
            foreach (Registo r in registos)
            {
                Registo.MostrarRegisto(r);
            }
        }


        public static void SalvarDadosRegistos()
        {
            Stream file = File.Open("dadosRegistos.bin", FileMode.Create, FileAccess.ReadWrite);
            BinaryFormatter bfw = new BinaryFormatter();
            bfw.Serialize(file, registos);

            file.Close();
        }
        public static void CarregarDadosRegistos()
        {
            Stream file = File.Open("dadosRegistos.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter b = new BinaryFormatter();
            if (file.Length != 0)
                registos = (List<Registo>)b.Deserialize(file);

            file.Close();
        }
    }
}
