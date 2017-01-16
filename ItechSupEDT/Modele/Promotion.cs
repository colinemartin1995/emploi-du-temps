using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Promotion : Destinataire
    {
        private int id;
        private String nom;
        private DateTime dateDebut;
        private DateTime dateFin;
        private List<Eleve> listEleves;
        private Formation formation;
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
        public DateTime DateDebut
        {
            get { return this.dateDebut; }
            set { this.dateDebut = value; }
        }
        public DateTime DateFin
        {
            get { return this.dateFin; }
            set { this.dateFin = value; }
        }
        public List<Eleve> ListEleves
        {
            get { return this.listEleves; }
            set { this.listEleves = value; }
        }
        public Formation Formation
        {
            get { return this.formation; }
            set { this.formation = value; }
        }
        public List<Session> ListSessions
        {
            get { return this.listSessions; }
            set { this.listSessions = value; }
        }
        public Promotion(int _id, String _nom, DateTime _dateDebut, DateTime _dateFin, Formation _formation)
        {
            this.id = _id;
            this.Nom = _nom;
            this.DateDebut = _dateDebut;
            this.DateFin = _dateFin;
            this.Formation = _formation;
            this.ListSessions = new List<Session>();
            this.ListEleves = new List<Eleve>();
        }
        public Promotion(int _id, String _nom, DateTime _dateDebut, DateTime _dateFin) : this(_id, _nom, _dateDebut, _dateFin, null)
        {

        }
        public void AddEleve(Eleve eleve)
        {
            if (this.ListEleves.Count > 24)
            {
                throw new PromotionException("La promotion est complète");
            }
            this.ListEleves.Add(eleve);
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
        public class PromotionException : Exception
        {
            public PromotionException(string message) : base(message)
            {
            }
        }
    }
}
