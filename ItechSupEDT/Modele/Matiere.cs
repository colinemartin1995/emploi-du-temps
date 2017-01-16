using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Matiere : Nameable
    {
        private int id;
        private String nom;
        private List<Formation> listFormations;
        private List<Session> listSessions;
        private List<Formateur> listFormateurs;
        public int Id
        {
            get { return this.id; }
        }
        public String Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public List<Formation> ListFormations
        {
            get { return this.listFormations; }
            set { this.listFormations = value; }
        }
        public List<Session> ListSessions
        {
            get { return this.listSessions; }
            set { this.listSessions = value; }
        }
        public List<Formateur> ListFormateurs
        {
            get { return this.listFormateurs; }
            set { this.listFormateurs = value; }
        }
        public Matiere(int _id, String _nom) : this(_id, _nom, new List<Formation>())
        {

        }
        public Matiere(int _id, String _nom, List<Formation> _lstFormations)
        {
            this.id = _id;
            this.Nom = _nom;
            this.ListSessions = new List<Session>();
            this.ListFormateurs = new List<Formateur>();
            this.ListFormations = _lstFormations;
        }
        public String getNom()
        {
            return this.Nom;
        }
    }
}
