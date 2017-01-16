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
        private List<Promotion> listPromotions;
        private List<Matiere> listMatiere;
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
        public List<Promotion> ListPromotions
        {
            get { return this.listPromotions; }
            set { this.listPromotions = value; }
        }
        public List<Matiere> ListMatiere
        {
            get { return this.listMatiere; }
            set { this.listMatiere = value; }
        }
        public Formation(int _id, String _nom, float _nbHeuresTotal)
        {
            this.id = _id;
            this.Nom = _nom;
            this.NbHeuresTotal = _nbHeuresTotal;
            this.ListMatiere = new List<Matiere>();
            this.ListPromotions = new List<Promotion>();
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
