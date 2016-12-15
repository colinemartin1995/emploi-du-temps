using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItechSupEDT.Modele;
using System.Data;
using System.Data.SqlClient;

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

            try
            {
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
            catch (Exception e)
            {
                throw e;
            }
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
