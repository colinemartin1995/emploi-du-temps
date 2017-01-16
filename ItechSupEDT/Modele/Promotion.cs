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
        private List<Eleve> lstEleves;
        private Formation formation;
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
        public List<Eleve> LstEleves
        {
            get { return this.lstEleves; }
            set { this.lstEleves = value; }
        }
        public Formation Formation
        {
            get { return this.formation; }
            set { this.formation = value; }
        }
        public List<Session> LstSessions
        {
            get { return this.lstSessions; }
            set { this.lstSessions = value; }
        }
        public Promotion(int _id, String _nom, DateTime _dateDebut, DateTime _dateFin, Formation _formation)
        {
            this.id = _id;
            this.Nom = _nom;
            this.DateDebut = _dateDebut;
            this.DateFin = _dateFin;
            this.Formation = _formation;
            this.LstSessions = new List<Session>();
            this.LstEleves = new List<Eleve>();
        }
        public Promotion(int _id, String _nom, DateTime _dateDebut, DateTime _dateFin) : this(_id, _nom, _dateDebut, _dateFin, null)
        {

        }
        public void AddEleve(Eleve eleve)
        {
            if (this.LstEleves.Count > 24)
            {
                throw new PromotionException("La promotion est complète");
            }
            this.LstEleves.Add(eleve);
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
        public class PromotionException : Exception
        {
            public PromotionException(string message) : base(message)
            {
            }
        }
    }
}
