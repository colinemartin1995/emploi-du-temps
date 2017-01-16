using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Session
    {
        private DateTime dateDebut;
        private DateTime dateFin;
        private List<EmploisDuTemps> listEDT;
        private Promotion promotion;
        private Matiere matiere;
        private Formateur formateur;
        private Salle salle;
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
        public List<EmploisDuTemps> ListEDT
        {
            get { return this.listEDT; }
            set { this.listEDT = value; }
        }
        public Promotion Promotion
        {
            get { return this.promotion; }
            set { this.promotion = value; }
        }
        public Matiere Matiere
        {
            get { return this.matiere; }
            set { this.matiere = value; }
        }
        public Formateur Formateur
        {
            get { return this.formateur; }
            set { this.formateur = value; }
        }
        public Salle Salle
        {
            get { return this.salle; }
            set { this.salle = value; }
        }
        public Session(DateTime _dateDebut, DateTime _dateFin, Promotion _promo, Matiere _matiere, Salle _salle) : this(_dateDebut, _dateFin, _promo, _matiere, _salle, null)
        {

        }
        public Session(DateTime _dateDebut, DateTime _dateFin, Promotion _promo, Matiere _matiere, Salle _salle, Formateur _formateur)
        {
            this.DateDebut = _dateDebut;
            this.DateFin = _dateFin;
            this.Promotion = _promo;
            this.Matiere = _matiere;
            this.Salle = _salle;
            this.Formateur = _formateur;
        }
    }
}
