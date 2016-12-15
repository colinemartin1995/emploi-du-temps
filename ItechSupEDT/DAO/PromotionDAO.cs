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
    public static class PromotionDAO
    {
        public static Promotion CreerPromotion(String nom, DateTime dateDebut, DateTime dateFin, Formation formation)
        {
            if (nom == null)
                throw new PromotionDAOException("Le nom de la promotion n'est pas renseigné.");

            if (dateDebut == null)
                throw new PromotionDAOException("La date du début de la promotion n'est pas renseignée.");

            if (dateFin == null)
                throw new PromotionDAOException("La date du fin de la promotion n'est pas renseignée.");

            if (formation == null)
                throw new PromotionDAOException("La formation de la promotion n'est pas renseignée.");

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "INSERT INTO Promotion (Nom, DateDebut, DateFin, Formation_id) output INSERTED.Id VALUES (@Nom, @DateDebut, @DateFin, @FormationId);";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;

                SqlParameter paramNom = new SqlParameter("Nom", SqlDbType.VarChar);
                paramNom.Value = nom;
                cmd.Parameters.Add(paramNom);

                SqlParameter paramDateDebut = new SqlParameter("DateDebut", SqlDbType.DateTime);
                paramDateDebut.Value = dateDebut;
                cmd.Parameters.Add(paramDateDebut);

                SqlParameter paramDateFin = new SqlParameter("DateFin", SqlDbType.DateTime);
                paramDateFin.Value = dateFin;
                cmd.Parameters.Add(paramDateFin);

                SqlParameter paramFormationId = new SqlParameter("FormationId", SqlDbType.Int);
                paramFormationId.Value = formation.Id;
                cmd.Parameters.Add(paramFormationId);

                int idPromotion = (int)cmd.ExecuteScalar();

                return new Promotion(idPromotion, nom, dateDebut, dateFin, formation);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public class PromotionDAOException : Exception
        {
            public PromotionDAOException(string message) : base(message)
            {
            }
            public PromotionDAOException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
    }
}
