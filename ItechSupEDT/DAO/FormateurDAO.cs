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
    public class FormateurDAO
    {
        public static Formateur CreerFormateur(String nom, String prenom, String mail, String telephone, List<Matiere> lstMatieres)
        {
            Formateur formateur;

            if (nom == null)
                throw new FormationDAOException("Le nom du formateur n'est pas renseigné.");

            if (prenom == null)
                throw new FormationDAOException("Le prénom du formateur n'est pas renseignée.");

            if (mail == null)
                throw new FormationDAOException("Le mail du formateur n'est pas renseignée.");

            if (telephone == null)
                throw new FormationDAOException("Le numéro de téléphone du formateur n'est pas renseignée.");

            if (lstMatieres.Count < 1)
                throw new FormationDAOException("Le formateur doit avoir au moins une matière.");


            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Formateur (Nom, Prenom, mail, Telephone) output INSERTED.Id VALUES (@Nom, @Prenom, @mail, @Telephone);";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;

            SqlParameter paramNom = new SqlParameter("Nom", SqlDbType.VarChar);
            paramNom.Value = nom;
            cmd.Parameters.Add(paramNom);

            SqlParameter paramPrenom = new SqlParameter("Prenom", SqlDbType.VarChar);
            paramPrenom.Value = prenom;
            cmd.Parameters.Add(paramPrenom);

            SqlParameter paramMail = new SqlParameter("Mail", SqlDbType.VarChar);
            paramMail.Value = mail;
            cmd.Parameters.Add(paramMail);

            SqlParameter paramTel = new SqlParameter("Telephone", SqlDbType.VarChar);
            paramTel.Value = telephone;
            cmd.Parameters.Add(paramTel);

            int idFormateur = (int)cmd.ExecuteScalar();

            formateur = new Formateur(idFormateur, nom, prenom, mail, telephone, lstMatieres);

            cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Formateur_matiere (Formateur_id, Matiere_id) VALUES ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;

            int i = 0;

            foreach (Matiere mat in formateur.LstMatiere)
            {
                String formateurIdParamName = "@Formateur_id" + i;
                String MatiereIdParamName = "@Matiere_id" + i;

                cmd.CommandText += "(" + formateurIdParamName + ", " + MatiereIdParamName + "),";

                SqlParameter paramFormateurId = new SqlParameter(formateurIdParamName, SqlDbType.Int);
                paramFormateurId.Value = formateur.Id;
                cmd.Parameters.Add(paramFormateurId);

                SqlParameter paramMatiereId = new SqlParameter(MatiereIdParamName, SqlDbType.Int);
                paramMatiereId.Value = mat.Id;
                cmd.Parameters.Add(paramMatiereId);
                i++;
            }
            cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 1);
            cmd.CommandText += ";";
            //throw new FormationDAOException(cmd.CommandText);

            cmd.ExecuteReader();

            return formateur;
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
