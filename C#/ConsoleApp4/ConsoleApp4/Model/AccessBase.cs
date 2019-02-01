using ConsoleApp4.Vue;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp4.Model
{
    class AccesBase
    {
        private string datasource;
        private string bdd;
        private DataSet ds;
        private SqlConnection con;
        private SqlCommand cmd;



        public AccesBase(string datasource, string bdd)
        {
            cmd = new SqlCommand();
            ds = new DataSet();
            this.datasource = datasource;
            this.bdd = bdd;

        }


        //Connection à la BDD
        public SqlConnection ConnectBDD()
        {

            con = new SqlConnection();
            con.ConnectionString = @"Data source =" + datasource + "; Initial Catalog =" + bdd + "; Integrated security = SSPI";
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                OutilVue.Afficher("Problème de connexion");


            }
            return con;

        }

        // ##################################################
        // Deconnection à la BDD
        public void DisconBDD()
        {
            try
            {
                con = new SqlConnection();
                con.Close();
            }
            catch (Exception e)
            {
                OutilVue.Afficher(e.Message);

            }
        }

        // ##################################################
        // Affichage de la BDD
        public DataSet Select(String requete)
        {
            try
            {
                ds.Clear();
                cmd.CommandText = requete;
                cmd.Connection = con;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "Resultats");

            }
            catch (Exception e)
            {
                OutilVue.Afficher(e.Message);

            }
            return ds;


        }


        // ##################################################
        // Accès à la BDD pour ajouter, modifier ou supprimer 

        public void Access(String requete)
        {

            try
            {
                cmd.Connection = con;
                cmd.CommandText = requete;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                OutilVue.Afficher(e.Message);

            }

        }


    }
}
