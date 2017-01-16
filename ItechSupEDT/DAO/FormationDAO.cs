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

            if (nom == null)
                throw new FormationDAOException ("Le nom de la formation n'est pas renseigné.");

            if (nbHeuresTotalStr == null)
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
            return Select(null);
        }
        public static List<Formation> Select(List<SQLcondition> listConditions)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            List<Formation> listFormations = new List<Formation>();

            try
            {
                cmd.CommandText = "SELECT Id, Nom, NbHeures FROM Formation";
                if (listConditions == null)
                {
                    for (int i = 0; i < listConditions.Count; i++)
                    {
                        SQLcondition condi = listConditions[i];
                        if (i == 0)
                        {
                            cmd.CommandText += " WHERE " + condi.ToString();
                        }
                        else
                        {
                            cmd.CommandText += " AND " + condi.ToString();
                        }
                    }
                }
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id;
                    Int32.TryParse(reader["Id"].ToString(), out id);
                    String nom = reader["Nom"].ToString();
                    float nbHeures;
                    float.TryParse(reader["NbHeures"].ToString(), out nbHeures);
                    listFormations.Add(new Formation(id, nom, nbHeures));
                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw new FormationDAOException("Erreur lors de l'accès à la base de donnée : ", e);
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
