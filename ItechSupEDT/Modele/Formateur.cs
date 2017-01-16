using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Formateur : Destinataire
    {
        private int id;
        private String nom;
        private String prenom;
        private String mail;
        private String telephone;
        private List<Matiere> listMatiere;
        private List<Session> listSessions;
        public int Id
        {
            get { return this.id; }
        }
        public String Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public String Prenom
        {
            get { return this.prenom; }
            set { this.prenom = value; }
        }
        public String Mail
        {
            get { return this.mail; }
            set { this.mail = value; }
        }
        public String Telephone
        {
            get { return this.telephone; }
            set { this.telephone = value; }
        }
        public List<Matiere> ListMatiere
        {
            get { return this.listMatiere; }
            set { this.listMatiere = value; }
        }
        public List<Session> ListSessions
        {
            get { return this.listSessions; }
            set { this.listSessions = value; }
        }
        
        public Formateur(int _id, String _nom, String _prenom, String _mail, String _telephone, List<Matiere> _listMatiere)
        {
            if (_listMatiere.Count < 1)
            {
                throw new FormateurException("Un formateur doit avoir au moins une matière.");
            }
            this.id = _id;
            this.Nom = _nom;
            this.Prenom = _prenom;
            this.Mail = _mail;
            this.Telephone = _telephone;
            this.ListMatiere = _listMatiere;
            this.ListSessions = new List<Session>();
        }
        public float NbHeuresTravaillees(DateTime _dateDebut, DateTime _dateFin)
        {
            float nbHeuresTravaillees = 0;
            foreach (Session session in this.ListSessions)
            {
                if (session.DateDebut > _dateDebut && session.DateFin < _dateFin)
                {
                    nbHeuresTravaillees += (float)(session.DateFin.Subtract(session.DateDebut).TotalHours);
                }
            }
            return nbHeuresTravaillees;
        }
        public bool EstDisponible(DateTime _dateDebut, DateTime _dateFin)
        {
            bool disponible = true;
            foreach (Session session in this.ListSessions)
            {
                bool conflitDebut = (_dateDebut > session.DateDebut) && (_dateDebut < session.DateFin);
                bool conflitFin = (_dateFin > session.DateDebut) && (_dateFin < session.DateFin);
                if (conflitDebut || conflitFin)
                {
                    disponible = false;
                }
            }
            return disponible;
        }
        List<Session> Destinataire.GetSessions(DateTime _dateDebut, DateTime _dateFin)
        {
            List<Session> lstSessions = new List<Session>();
            foreach (Session session in this.ListSessions)
            {
                if (session.DateDebut > _dateDebut && session.DateFin < _dateFin)
                {
                    lstSessions.Add(session);
                }
            }
            return lstSessions;
        }
        public class FormateurException : Exception
        {
            public FormateurException(string message) : base(message)
            {
            }
        }
    }
}
