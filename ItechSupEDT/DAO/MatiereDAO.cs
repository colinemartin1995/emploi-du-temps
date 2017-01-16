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
    public class MatiereDAO
    {
        public static Matiere CreerMatiere(String nom, List<Formation> lstFormation)
        {
            Matiere matiere;

            if (nom == null)
                throw new MatiereDAOException("Le nom de la matière n'est pas renseigné.");

            if (lstFormation.Count == 0)
                throw new MatiereDAOException("Au moins une formation doit être renseignée.");

            SqlCommand cmd = new SqlCommand();
                
            cmd.CommandText = "INSERT INTO Matiere (Nom) output INSERTED.Id VALUES (@Nom);";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;

            SqlParameter paramNom = new SqlParameter("Nom", SqlDbType.VarChar);
            paramNom.Value = nom;
            cmd.Parameters.Add(paramNom);
            int idMatiere = (int)cmd.ExecuteScalar();
            matiere = new Matiere(idMatiere, nom, lstFormation);

            cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Formation_matiere (Formation_id, Matiere_id) VALUES ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;

            int i = 0;

            foreach (Formation formation in matiere.LstFormations)
            {
                String formationIdParamName = "@Formation_id" + i;
                String MatiereIdParamName = "@Matiere_id" + i;
                cmd.CommandText += "(" + formationIdParamName + ", " + MatiereIdParamName + "),";
                SqlParameter paramFormationId = new SqlParameter(formationIdParamName, SqlDbType.Int);
                paramFormationId.Value = formation.Id;
                cmd.Parameters.Add(paramFormationId);

                SqlParameter paramMatiereId = new SqlParameter(MatiereIdParamName, SqlDbType.Int);
                paramMatiereId.Value = matiere.Id;
                cmd.Parameters.Add(paramMatiereId);
                i++;
            }
            cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1);
            cmd.CommandText += ";";

            cmd.ExecuteReader();

            return matiere;
        }
        public class MatiereDAOException : Exception
        {
            public MatiereDAOException(string message) : base(message)
            {
            }
            public MatiereDAOException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
    }
}
