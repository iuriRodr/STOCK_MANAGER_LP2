//Trabalho prático LP 2
//Iúri Rodrigues 21159
//
//
//


using Dados;
using BO;
using System.Collections.Generic;
using System;

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

        public static List<double> ShowStat()
        {
         
            return Artigos.ShowStats();
        }

        public static Artigo Search(int id)
        {
           return Artigos.SearchArtigoId(id);

        }

        public static void SaveAllData()
        {
            Artigos.SaveData();
        }

        public static void LoadAllData()
        {
            Artigos.LoadData();
        }
        public static List<Registo> ShowRecord()
        {
            //Registos.ShowRecords();
            return Registos.ShowRecords();
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
