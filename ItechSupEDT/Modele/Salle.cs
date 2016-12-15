using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Salle : Destinataire 
    {
        private int id;
        private String nom;
        private int capacite;
        private List<Session> lstSessions;
        public int Id
        {
            get { return this.id; }
        }
        public String Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public int Capacite
        {
            get { return this.capacite; }
            set { this.capacite = value; }
        }
        public List<Session> LstSessions
        {
            get { return this.lstSessions; }
            set { this.lstSessions = value; }
        }
        public Salle(int _id, String _nom, int _capacite)
        {
            this.id = _id;
            this.Nom = _nom;
            this.Capacite = _capacite;
            this.LstSessions = new List<Session>();
        }
        public bool EstDisponible(DateTime _dateDebut, DateTime _dateFin)
        {
            bool disponible = true;
            foreach (Session session in this.LstSessions)
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
            foreach (Session session in this.LstSessions)
            {
                if (session.DateDebut > _dateDebut && session.DateFin < _dateFin)
                {
                    lstSessions.Add(session);
                }
            }
            return lstSessions;
        }
    }
}
