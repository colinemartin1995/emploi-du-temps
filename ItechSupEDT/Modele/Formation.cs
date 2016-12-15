using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Formation : Nameable
    {
        private int id;
        private String nom;
        private float nbHeuresTotal;
        private List<Promotion> lstPromotions;
        private List<Matiere> lstMatiere;
        public int Id
        {
            get { return this.id; }
        }
        public String Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public float NbHeuresTotal
        {
            get { return this.nbHeuresTotal; }
            set { this.nbHeuresTotal = value; }
        }
        public List<Promotion> LstPromotions
        {
            get { return this.lstPromotions; }
            set { this.lstPromotions = value; }
        }
        public List<Matiere> LstMatiere
        {
            get { return this.lstMatiere; }
            set { this.lstMatiere = value; }
        }
        public Formation(int _id, String _nom, float _nbHeuresTotal)
        {
            this.id = _id;
            this.Nom = _nom;
            this.NbHeuresTotal = _nbHeuresTotal;
            this.LstMatiere = new List<Matiere>();
            this.LstPromotions = new List<Promotion>();
        }
        public class FormationException : Exception
        {
            public FormationException(string message) : base(message)
            {
            }
        }
        public string getNom()
        {
            return this.Nom;
        }
    }
}
