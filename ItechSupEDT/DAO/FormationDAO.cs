using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItechSupEDT.Modele;
using System.Data;
using System.Data.SqlClient;
using ItechSupEDT.Outils;

namespace ItechSupEDT.DAO
{
    public class FormationDAO
    {
        public static Formation CreerFormation(String nom, String nbHeuresTotalStr)
        {
            float nbHeuresTotal;

            if (nom == null || nom == "")
                throw new FormationDAOException ("Le nom de la formation n'est pas renseigné.");

            if (nbHeuresTotalStr == null || nbHeuresTotalStr == "")
                throw new FormationDAOException("La durée de la formation n'est pas renseignée.");
            
            try
            {
                nbHeuresTotal = float.Parse(nbHeuresTotalStr);
            }
            catch (Exception e)
            {
                throw new FormationDAOException("La durée de la formation renseignée n'est pas valide.", e);
            }
            
            SqlCommand cmd = new SqlCommand();
                
            cmd.CommandText = "INSERT INTO Formation (Nom, NbHeuresTotal) output INSERTED.Id VALUES (@Nom, @NbHeuresTotal);";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;

            SqlParameter paramNom = new SqlParameter("Nom", SqlDbType.VarChar);
            paramNom.Value = nom;
            cmd.Parameters.Add(paramNom);

            SqlParameter paramNbHeures = new SqlParameter("NbHeuresTotal", SqlDbType.Float);
            paramNbHeures.Value = nbHeuresTotal;
            cmd.Parameters.Add(paramNbHeures);

            int idFormation = (int)cmd.ExecuteScalar();
                
            return new Formation(idFormation, nom, nbHeuresTotal);
        }
        public static List<Formation> GetAll()
        {
            List<Formation> listFormations = new List<Formation>();
            String nom = "";
            int id;
            float nbHeures = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                cmd.CommandText = "SELECT Id, Nom, NbHeuresTotal FROM Formation;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = int.Parse(reader["Id"].ToString());
                    nom = reader["Nom"].ToString();
                    nbHeures = float.Parse(reader["NbHeuresTotal"].ToString());
                    listFormations.Add(new Formation(id, nom, nbHeures));
                }
                reader.Close();
            }
            catch (Exception error)
            {
                throw new FormationDAOException("Erreur lors de l'accès à la base de donnée : ", error);
            }
            return listFormations;
        }
        public class FormationDAOException : Exception
        {
            public FormationDAOException(string message) : base(message)
            {
            }
            public FormationDAOException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
    }
}
