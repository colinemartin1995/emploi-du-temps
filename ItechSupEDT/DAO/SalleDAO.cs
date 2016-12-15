using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItechSupEDT.Modele;
using System.Data.SqlClient;
using System.Data;

namespace ItechSupEDT.DAO
{
    public static class SalleDAO
    {
        public static Salle CreerPromotion(String nom, String capaciteStr)
        {
            int capacite;
            if (nom == null)
                throw new SalleDAOException("Le nom de la salle n'est pas renseigné.");

            if (capaciteStr == null)
                throw new SalleDAOException("La capacité de la salle n'est pas renseignée.");

            try
            {
                capacite = int.Parse(capaciteStr);
            }
            catch (Exception e)
            {
                throw new SalleDAOException("La capacité de la salle renseignée n'est pas valide.", e);
            }

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "INSERT INTO Salle (Nom, Capacite) output INSERTED.Id VALUES (@Nom, @Capacite);";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;

                SqlParameter paramNom = new SqlParameter("Nom", SqlDbType.VarChar);
                paramNom.Value = nom;
                cmd.Parameters.Add(paramNom);

                SqlParameter paramCapacite = new SqlParameter("Capacite", SqlDbType.Int);
                paramCapacite.Value = capacite;
                cmd.Parameters.Add(paramCapacite);

                int idSalle = (int)cmd.ExecuteScalar();

                return new Salle(idSalle, nom, capacite);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public class SalleDAOException : Exception
        {
            public SalleDAOException(string message) : base(message)
            {
            }
            public SalleDAOException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
    }
}
