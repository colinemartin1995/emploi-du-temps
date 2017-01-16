﻿using System;
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
    public class EleveDAO
    {
        public static Eleve CreerEleve(String nom, String prenom, String mail, Promotion promotion)
        {
            if (nom == null)
                throw new EleveDAOException("Le nom de l'élève n'est pas renseigné.");

            if (prenom == null)
                throw new EleveDAOException("Le prénom de l'élève n'est pas renseigné.");

            if (mail == null)
                throw new EleveDAOException("Le mail de l'élève n'est pas renseigné.");

            if (promotion == null)
                throw new EleveDAOException("La promotion de l'élève n'est pas renseignée.");
            
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Eleve (Nom, Prenom, Mail, Promotion_id) output INSERTED.Id VALUES (@Nom, @Prenom, @Mail, @Promotion_id);";
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

            SqlParameter paramPromotionId = new SqlParameter("Promotion_id", SqlDbType.Int);
            paramPromotionId.Value = promotion.Id;
            cmd.Parameters.Add(paramPromotionId);

            int idEleve = (int)cmd.ExecuteScalar();

            return new Eleve(idEleve, nom, prenom, mail, promotion);
        }
        public static List<Eleve> GetAll()
        {
            return Select(null);
        }
        public static List<Eleve> Select(List<SQLcondition> listConditions)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            List<Eleve> lstEleves = new List<Eleve>();

            try
            {
                cmd.CommandText = "SELECT Id, Nom, Prenom, Mail FROM Eleve";
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
                    String prenom = reader["Prenom"].ToString();
                    String mail = reader["Mail"].ToString();
                    lstEleves.Add(new Eleve(id, nom, prenom, mail));
                }
                reader.Close();
            }
            catch (Exception e)
            {
                throw new EleveDAOException("Erreur lors de l'accès à la base de donnée : ", e);
            }
            return lstEleves;
        }
        public class EleveDAOException : Exception
        {
            public EleveDAOException(string message) : base(message)
            {
            }
            public EleveDAOException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
    }
}
