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
        public int Capacite
        {
            get { return this.capacite; }
            set { this.capacite = value; }
        }
        public List<Session> ListSessions
        {
            get { return this.listSessions; }
            set { this.listSessions = value; }
        }
        public Salle(int _id, String _nom, int _capacite)
        {
            this.id = _id;
            this.Nom = _nom;
            this.Capacite = _capacite;
            this.ListSessions = new List<Session>();
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
            List<Session> listSessions = new List<Session>();
            foreach (Session session in this.ListSessions)
            {
                if (session.DateDebut > _dateDebut && session.DateFin < _dateFin)
                {
                    listSessions.Add(session);
                }
            }
            return listSessions;
        }
    }
}
