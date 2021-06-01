using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using BO;

namespace BR
{
    public class Regras
    {
        public static void InsertArt(Artigo a)
        {
            Artigos.InsertArtigo(a);
        }

        public static void ShowArt()
        {
            Artigos.ShowArtigos();
        }

        public static void ShowStat(Artigo a)
        {
            Artigos.ShowStats(a);
        }

        public static Artigo Search()
        {
           return Artigos.SearchArtigoId();

        }

        public static void SaveAllData()
        {
            Artigos.SaveData();
        }

        public static void LoadAllData()
        {
            Artigos.LoadData();
        }
        public static void ShowRecord()
        {
            Registos.ShowRecords();
        }

        public static bool InsertRecor(Registo a)
        {
            Registos.InsertRecord(a);
            return true;
        }

        public static Artigo AddArt(Artigo a)
        {
             return Artigo.AddArtigo(a);
        }

        public static void ShowArtt(Artigo a)
        {
            Artigo.ShowArtigo(a);
        }

        public static bool EditArtt(Artigo a)
        {
           return Artigo.EditArtigo(a);
           
        }

        public static bool SellArt(Artigo a)
        {
            return Artigo.Sell(a);
            
        }



       
    }
}
